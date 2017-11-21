﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDLayouts.ViewModels
{
    public class DeliveryRecipientViewModel : BaseViewModel
    {
        private bool? _isNameValid;
        public bool? IsNameValid
        {
            get => _isNameValid;
            set
            {
                Set(ref _isNameValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private bool? _isSurnameValid;
        public bool? IsSurnameValid
        {
            get => _isSurnameValid;
            set
            {
                Set(ref _isSurnameValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private bool? _isPatronymValid;
        public bool? IsPatronymValid
        {
            get => _isPatronymValid;
            set
            {
                Set(ref _isPatronymValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private bool? _isPhoneValid;
        public bool? IsPhoneValid
        {
            get => _isPhoneValid;
            set
            {
                Set(ref _isPhoneValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private bool? _isEmailValid;
        public bool? IsEmailValid
        {
            get => _isEmailValid;
            set
            {
                Set(ref _isEmailValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        private bool? _isSecondPhoneValid;
        public bool? IsSecondPhoneValid
        {
            get => _isSecondPhoneValid;
            set
            {
                Set(ref _isSecondPhoneValid, value);
                RaisePropertyChanged(nameof(IsViewValid));
            }
        }

        public bool IsViewValid => (IsNameValid != null && IsNameValid.Value) &&
                                        (IsSurnameValid != null && IsSurnameValid.Value) &&
                                        ((IsPatronymValid != null && IsPatronymValid.Value) || (IsPatronymValid == null)) &&
                                        (IsPhoneValid != null && IsPhoneValid.Value) &&
                                        ((IsEmailValid != null && IsEmailValid.Value) || (IsEmailValid == null)) &&
                                        ((IsSecondPhoneValid != null && IsSecondPhoneValid.Value) || (IsSecondPhoneValid == null));
    }
}
