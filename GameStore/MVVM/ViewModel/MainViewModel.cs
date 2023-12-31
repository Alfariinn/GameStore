﻿using GameStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameStore.MVVM.ViewModel
{
     class MainViewModel : ObservableObject
    {
        
        public RelayCommand StoreViewCommand { get; set; }

        public RelayCommand LibraryViewCommand { get; set; }

        public object Username { get; set; }

        private object _currrentView;

        public StoreViewModel StoreVM { get; set; }

        public LibraryViewModel LibraryVM { get; set; }

        public object CurrentView
        {
            get { return _currrentView; }
            set 
            {   _currrentView = value;
                OnPropertyChanged();

            }
        }

        public MainViewModel() 
        {
            StoreVM = new StoreViewModel();
            LibraryVM = new LibraryViewModel();
            CurrentView = StoreVM;

            Username = Application.Current.Resources["UserName"];

            StoreViewCommand = new RelayCommand(o => 
            {
                CurrentView = StoreVM;
            });

            LibraryViewCommand = new RelayCommand(o =>
            {
                CurrentView = LibraryVM;
            });
        }
    }
}
