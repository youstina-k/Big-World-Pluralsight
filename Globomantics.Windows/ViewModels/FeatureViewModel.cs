using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using Globomantics.Windows.Messages;
namespace Globomantics.Windows.ViewModels
{
    public class FeatureViewModel :BaseTodoViewModel<Feature>
    {
        private readonly IRepository<Feature> repository;
        private string description;
        private DateTime dueDate = DateTime.UtcNow;
        public string? Description
        {
            get =>description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public FeatureViewModel(IRepository<Feature> repository) :base()
        {
            this.repository = repository;
            SaveCommand = new RelayCommand(async () => await SaveAsync());
        }
        public override void UpdateModel(Todo model)
        {
            if (model is not Feature feature) { return; }
            base.UpdateModel(feature);
            Description = feature.Description;
            DueDate = feature.DueDate;
        }
        public override async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                ShowError?.Invoke($"{nameof(Title)} cannot be empty");
                return;
            }

            if (Model is null)
            {
                Model = new Feature(Title, Description,"", 1,
                    App.CurrentUser, App.CurrentUser)
                {
                    
                    Parent = Parent,
                    DueDate=DueDate,
                    IsCompleted = IsCompleted,
                    IsDeleted = IsDeleted
                };
            }
            else
            {
                Model = Model with
                {
                    Title = Title,
                    Description = Description,
                    DueDate = DueDate,
                    Parent = Parent,
                    IsCompleted = IsCompleted,
                    IsDeleted = IsDeleted
                };
            }
            try
            {
                await repository.AddAsync(Model);
                await repository.SaveChangesAsync();
                WeakReferenceMessenger.Default.Send<TodoSavedMessage>(new(Model));

            }
            catch(Exception ex) { 
                ShowError?.Invoke("couldn't save to the database"); }
        }
    }
}
