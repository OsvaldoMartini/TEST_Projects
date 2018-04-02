﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Modal.Interfaces;

namespace Modal.Concrete
{
    public class GlobalServices
    {
        public static IModalService ModalService
        {
            get { return (IModalService)Application.Current.MainWindow; }
        }
    }
}
