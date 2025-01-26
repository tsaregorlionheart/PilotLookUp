﻿using PilotLookUp.Commands;
using PilotLookUp.Enums;
using PilotLookUp.Model;
using PilotLookUp.Objects;
using PilotLookUp.Utils;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace PilotLookUp.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        private LookUpModel _lookUpModel { get; }
        private PageController _pageController { get; }

        public MainVM(LookUpModel lookUpModel, PagesName startPage = PagesName.None)
        {
            _lookUpModel = lookUpModel;
            _pageController = new PageController(_lookUpModel,this, startPage);
        }

        public UserControl SelectedControl
        {
            get => _pageController.ActivePage as UserControl;
        }

        private void LookDB()
        {
            _pageController.CreatePage(PagesName.DBPage);
            OnPropertyChanged("SelectedControl");
        }

        public ICommand LookDBCommand => new RelayCommand<object>(_ => LookDB());

        private void Search()
        {
            _pageController.GoToPage(PagesName.SearchPage);
            OnPropertyChanged("SelectedControl");
        }

        public ICommand SearchCommand => new RelayCommand<object>(_ => Search());

        public void ChangePage(PilotObjectHelper pageType)
        {
            _pageController.CreatePage(PagesName.LookUpPage, pageType);
            OnPropertyChanged("SelectedControl");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
