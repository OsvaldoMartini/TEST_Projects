using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Binding.StaticResource.AddNew.Abstract;
using Binding.StaticResource.AddNew.Model;

namespace Binding.StaticResource.AddNew.ViewModel
{
    public class ListFilesPath : ViewModelBase
    {
        #region Constructor
        public ListFilesPath()
        {
            setFiles();
        }
        #endregion Constructor

        #region Properties
        #region SelectedFileObject
        private FileObject selectedFileObjects;
        public FileObject SelectedFileObject
        {
            get { return selectedFileObjects; }
            set
            {
                if (value != this.selectedFileObjects)
                    selectedFileObjects = value;
                this.SetPropertyChanged("SelectedFileObject");
            }
        }
        #endregion SelectedFileObject

        #region FileObjectCollection
        private ObservableCollection<FileObject> fileObjectCollection;
        public ObservableCollection<FileObject> FileObjectCollection
        {
            get { return fileObjectCollection; }
            set
            {
                if (value != this.fileObjectCollection)
                    fileObjectCollection = value;
                this.SetPropertyChanged("FileObjectCollection");
            }
        }
        #endregion FileObjectCollection

        #region Path
        //Use Your own path
        private string path = @"D:\Projetos";
        public string Path
        {
            get { return path; }
            set
            {
                if (value != this.path)
                    path = value;
                this.SetPropertyChanged("Path");
            }
        }
        #endregion Path
        #endregion Properties

        #region Mehods
        #region void setFiles()
        private void setFiles()
        {
            if (this.path != string.Empty)
            {
                DirectoryInfo dInfo = new DirectoryInfo(this.path);
                //use any extension you want.
                FileInfo[] fInfo = dInfo.GetFiles("*.txt");
                fInfo.Cast<FileInfo>().ToList().ForEach(setFileObjectCollection());
            }
        }
        #endregion void setFiles()

        #region Action<FileInfo> setFileObjectCollection()
        private Action<FileInfo> setFileObjectCollection()
        {
            this.fileObjectCollection = new ObservableCollection<FileObject>();
            return f => this.fileObjectCollection.Add(new FileObject { FileName = f.Name, Location = f.DirectoryName });
        }
        #endregion Action<FileInfo> setFileObjectCollection()
        #endregion Mehods
    }
}
