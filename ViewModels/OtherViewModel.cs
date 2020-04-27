// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OtherViewModel.cs" company="Watson Laboratory">
//   Copyright © 2020 Watson Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Caliburn.Micro;

namespace Intent.ViewModels
{
    public class OtherViewModel : Screen
    {
        public void Close()
        {
            this.TryClose();
        }
    }
}