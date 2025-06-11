using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using Globomantics.Windows.Messages;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Globomantics.Windows.ViewModels;

public class MainViewModel : ObservableObject, 
    IViewModel
{
    private string statusText = "Everything is OK!";
    private bool isInitialized;
    private readonly IRepository<User> userRepository;
    private readonly IRepository<TodoTask> todoRepository;
    private string searchText = "";
    private bool isLoading;
    public string StatusText 
    {
        get => statusText;
        set
        {
            statusText = value;

            OnPropertyChanged(nameof(StatusText));
        }
    }
    public bool IsLoading
    {
        get => isLoading;
        set
        {
            isLoading = value;

            OnPropertyChanged(nameof(IsLoading));
        }
    }
    public string SearchText
    {
        get => searchText;
        set
        {
            searchText = value;
            OnPropertyChanged(nameof(searchText));
        }
    }

    public ICommand SearchCommand { get; set; }

    public Action<string>? ShowAlert { get; set; }
    public Action<string>? ShowError { get; set; }
    public Func<IEnumerable<string>>? ShowOpenFileDialog { get; set; }
    public Func<string>? ShowSaveFileDialog { get; set; }
    public Func<string, bool>? AskForConfirmation { get; set; }

    public ObservableCollection<Todo> Completed { get; set; } = new();
    public ObservableCollection<Todo> Unfinished { get; set; } = new();
    public MainViewModel(IRepository<User> userRepository, IRepository<TodoTask> todoRepository)
    {
        WeakReferenceMessenger.Default.Register<TodoSavedMessage>
            (this,async (sender, message) =>
        {
              var item = message.Value;

            if (item.IsCompleted)
            {
                var existing = Unfinished.FirstOrDefault(i => i.Id == item.Id);
                if (existing != null)
                {
                    Unfinished.Remove(existing);
                }
                ReplaceorAdd(Completed, item);
                await todoRepository.SaveChangesAsync();
            }
            else
            {
                var existing = Completed.FirstOrDefault(i => i.Id == item.Id);
                if (existing != null)
                {
                    Completed.Remove(existing);
                }
                ReplaceorAdd(Unfinished, item);
                await todoRepository.SaveChangesAsync();
            }
        });
        WeakReferenceMessenger.Default.Register<TodoDeletedMessage>
            (this,async (sender, message) =>
        {
            var item = message.Value;
            
            var unfinishedItem = Unfinished.FirstOrDefault(i => i.Id == item.Id);
            if (unfinishedItem != null)
                {
                   
                   Unfinished.Remove(unfinishedItem);
                await todoRepository.DeleteAsync((TodoTask)unfinishedItem);
                await todoRepository.SaveChangesAsync();

            }
            var completedItem = Completed.FirstOrDefault(i => i.Id == item.Id);
              if (completedItem != null)
              {
                    Completed.Remove(completedItem);
                await todoRepository.DeleteAsync((TodoTask)completedItem);
                await todoRepository.SaveChangesAsync();

            }
        });
        this.userRepository = userRepository;
        this.todoRepository = todoRepository;

        SearchCommand = new RelayCommand(async () =>
        {
            Unfinished.Clear();
            var items = await todoRepository.GetAllAsync();
            var query = items.AsQueryable().Where(t => !t.IsCompleted && !t.IsDeleted);
            if (!string.IsNullOrWhiteSpace(searchText) && !searchText.Equals("*", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(t => t.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }
            foreach (var item in  query)
            {
                Unfinished.Add(item);
            }
        });
    }
        
    private void ReplaceorAdd(ObservableCollection<Todo> collection, Todo item)
    {
        var existeditem = collection.FirstOrDefault(x => x.Id == item.Id);
        if (existeditem != null)
        {
            var index = collection.IndexOf(existeditem);
            collection[index] = item;
        }
        else { 
            collection.Add(item);
            
        }
    }

    public async Task InitializeAsync()
    {
        if (isInitialized) return;
        App.CurrentUser = await userRepository.FindByAsync("youstina");

        var items = await todoRepository.GetAllAsync();
        foreach (var item in items.Where(item => !item.IsDeleted))
        {
            if (item.IsCompleted)
            {
                Completed.Add(item);
            }
            else
            {
                Unfinished.Add(item);
            }
        }
        int itemsDueCount = 0;
        foreach (var item in items)
        {
            if (Unfinished.Contains(item) && (item.DueDate < DateTime.Now))
            {
                itemsDueCount++;
            }
        }
        StatusText = $"Welcome {App.CurrentUser.Name}! " +
            $"You have {itemsDueCount} items passed due date.";
        isInitialized = true;
    }
}