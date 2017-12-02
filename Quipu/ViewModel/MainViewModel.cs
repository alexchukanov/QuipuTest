using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Quipu.Model;
using System;

using Quipu.Utils;
using System.Threading;

namespace Quipu.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private readonly IDataService _dataService;

        

        public MainViewModel(IDataService dataService)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _dataService = dataService;

            CountCommand = new RelayCommand(ExecuteCountCommand, CanExecuteCountCommand);
            LoadLinkCommand = new RelayCommand(ExecuteLoadLinkCommand);
        }

        private string message = "";
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                Set(ref message, value);
            }
        }

        private string link = "www.rbc.ru";
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                Set(ref link, value);
                this.CountCommand.RaiseCanExecuteChanged();
            }
        }

        private string tag = "a";
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                Set(ref tag, value);
                this.CountCommand.RaiseCanExecuteChanged();

            }
        }

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                Set(ref count, value);
            }
        }       

        private bool isProgress = false;       

        public bool IsProgress
        {
            get
            {
                return isProgress;
            }
            set
            {
                Set(ref isProgress, value);
            }
        }

        public RelayCommand CountCommand
        {
            get;
            private set;
        }

        
        private void ExecuteCountCommand()
        {
            Count = 0;
            Message = "";
            CountContentTag(Link, Tag);
        }

        private bool CanExecuteCountCommand()
        {           

            bool isValid = true;

            if (Tag == String.Empty || Link == String.Empty)
            {
                Message = "Fill fields!";
                isValid = false;
            }
            else if (!Util.IsUrlValid(Link))
            {
                Message = "Incorrect link!";
                isValid = false;
            }

            return isValid;
        }


        public void CountContentTag(string link, string tag)
        {  
            IsProgress = true;

            try
            {
              
                _dataService.CountLinkTag(
            (item, error) =>
            {
                if (error != null)
                {
                    IsProgress = false;
                    Message = error.Message;
                    return;
                }

                Count = item.CountTag;
                Message = String.Format("Tag '{0}' counted {1} times", Tag, Count);
                IsProgress = false;

            }, link, tag);

            }
            catch (Exception)
            {
                // Report error here
                Message = "Link connection error!";
                IsProgress = false;
            }            
        }



        public RelayCommand LoadLinkCommand
        {
            get;
            private set;
        }


        private void ExecuteLoadLinkCommand()
        {
            Count = 0;
            Message = "";
            LoadLinkFromFile();
        }

        public void LoadLinkFromFile()
        {

            IsProgress = true;

            try
            {

                _dataService.LoadLink(
            (item, error) =>
            {
                if (error != null)
                {
                    IsProgress = false;
                    Message = error.Message;
                    return;
                }

                Link = item.Link;
                IsProgress = false;

            } );

            }
            catch (Exception)
            {
                // Report error here
                Message = "Link connection error!";
                IsProgress = false;
            }
        }
    }
}