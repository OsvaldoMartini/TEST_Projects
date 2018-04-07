﻿using System;
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
        public ListFilesPath()
        {
            SetFiles();
        }
     
        private FileObject _selectedFileObjects;
        public FileObject SelectedFileObject
        {
            get { return _selectedFileObjects; }
            set
            {
                if (value != this._selectedFileObjects)
                    _selectedFileObjects = value;
                this.SetPropertyChanged("SelectedFileObject");
            }
        }
     
        private ObservableCollection<FileObject> _fileObjectCollection;
        public ObservableCollection<FileObject> FileObjectCollection
        {
            get { return _fileObjectCollection; }
            set
            {
                if (value != this._fileObjectCollection)
                    _fileObjectCollection = value;
                this.SetPropertyChanged("FileObjectCollection");
            }
        }
     
        //Use Your own path
        private string _path = @"D:\Projetos";
        public string Path
        {
            get { return _path; }
            set
            {
                if (value != this._path)
                    _path = value;
                this.SetPropertyChanged("Path");
            }
        }
     
        private void SetFiles()
        {
            if (this._path != string.Empty)
            {
                DirectoryInfo dInfo = new DirectoryInfo(this._path);
                //use any extension you want.
                FileInfo[] fInfo = dInfo.GetFiles("*.txt");
                fInfo.Cast<FileInfo>().ToList().ForEach(SetFileObjectCollection());
            }
        }
     
        private Action<FileInfo> SetFileObjectCollection()
        {
            this._fileObjectCollection = new ObservableCollection<FileObject>();
            return f => this._fileObjectCollection.Add(new FileObject { FileName = f.Name, Location = f.DirectoryName });
        }
    }
}
