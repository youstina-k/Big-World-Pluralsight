using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using Globomantics.Windows.Messages;

namespace Globomantics.Windows.ViewModels
{
    public class BugViewModel:BaseTodoViewModel<Bug>
    {
        private readonly IRepository<Bug> repository;
        private string description;
        private string affectedVersion;
        private int affectedUsers;
        private DateTime dueDate=DateTime.UtcNow;
        private Severity severity;
        public string? Description
        {
            get =>description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string AffectedVersion
        {
            get => affectedVersion;
            set
            {
                affectedVersion = value;
                OnPropertyChanged(nameof(AffectedVersion));
            }
        }
        public int AffectedUsers
        {
            get => affectedUsers;
            set
            {
                affectedUsers = value;
                OnPropertyChanged(nameof(AffectedUsers));
            }
        }
        public DateTime DueDate
        {
            get =>dueDate; 
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public Severity Severity
        {
            get => severity;
            set
            {
                severity = value;
                OnPropertyChanged(nameof(Severity));
            }
        }
        public IEnumerable<Severity> SeverityLevels { get; } = new[]
        {
            Severity.Critical,
            Severity.Annoying,
            Severity.Major,
            Severity.Minor 
        };
        public BugViewModel(IRepository<Bug> repository) : base()
        {
            this.repository = repository;
            SaveCommand = new RelayCommand(async () => await SaveAsync());
        }
        public override void UpdateModel(Todo model)
        {
            if (model is not Bug bug) { return; }
            base.UpdateModel(bug);
            Description = bug.Description;
            AffectedVersion = bug.AffectedVersion;
            AffectedUsers = bug.AffectedUsers;
            DueDate= bug.DueDate;
            Severity = bug.Severity;

           
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
                Model = new Bug(Title,Description,Severity,AffectedVersion,AffectedUsers,
                App.CurrentUser,App.CurrentUser)
                {
                    DueDate = DueDate,
                    Parent = Parent,
                    IsCompleted = IsCompleted,
                    IsDeleted =IsDeleted
                };
            }
            else
            {
                Model = Model with
                {
                    Title = Title,
                    Description = Description,
                    Severity = Severity,
                    AffectedVersion = AffectedVersion,
                    AffectedUsers = AffectedUsers,
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
            catch (Exception ex)
            {
                ShowError?.Invoke("couldn't save to the database");
            }
        }
    }
}
