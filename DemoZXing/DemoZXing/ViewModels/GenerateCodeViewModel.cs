using System;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

using DemoZXing.Helpers;

using ZXing;

using Xamarin.Forms;

namespace DemoZXing.ViewModels
{
    public class GenerateCodeViewModel : BaseViewModel
    {
        public ICommand GenerateCodeCommand { get; set; }

        private ObservableCollection<string> _formats;

        public ObservableCollection<string> Formats
        {
            get => _formats;
            set { _formats = value; OnPropertyChanged(); }
        }

        private string _code;

        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                ValidatedSelectedFormat = BarcodeFormat.QR_CODE;
                OnPropertyChanged();
            }
        }

        private string _validatedCode;

        public string ValidatedCode
        {
            get => _validatedCode;
            set { _validatedCode = value; OnPropertyChanged(); }
        }

        private BarcodeFormat _validatedSelectedFormat;

        public BarcodeFormat ValidatedSelectedFormat
        {
            get => _validatedSelectedFormat;
            set { _validatedSelectedFormat = value; OnPropertyChanged(); }
        }

        private BarcodeFormat _selectedFormat;

        public string SelectedFormat
        {
            get => BarcodeFormatConverter.ConvertEnumToString(_selectedFormat);
            set
            {
                _selectedFormat = (value != null) 
                    ? BarcodeFormatConverter.ConvertStringToEnum(value) 
                    : BarcodeFormat.QR_CODE;
                OnPropertyChanged();
            }
        }

        private string _error;

        public string Error
        {
            get => _error;
            set { _error = value; OnPropertyChanged(); }
        }


        public GenerateCodeViewModel()
        {
            GenerateCodeCommand = new Command(GenerateCode);
            _formats = new ObservableCollection<string>(Enum.GetNames(typeof(BarcodeFormat)));
            _validatedSelectedFormat = BarcodeFormatConverter.ConvertStringToEnum(_formats.First(x => x == "QR_CODE"));
            _validatedCode = "N/A";
            _error = "No error";
        }

        private void GenerateCode()
        {
            var validCode = true;
            _error = "No error";

            switch (_selectedFormat)
            {
                case BarcodeFormat.AZTEC:
                    break;
                case BarcodeFormat.CODABAR:
                    break;
                case BarcodeFormat.CODE_39:
                    break;
                case BarcodeFormat.CODE_93:
                    break;
                case BarcodeFormat.CODE_128:
                    break;
                case BarcodeFormat.DATA_MATRIX:
                    break;
                case BarcodeFormat.EAN_8:
                    validCode = BarcodeValidation.IsValidEan(_code, 8);
                    break;
                case BarcodeFormat.EAN_13:
                    validCode = BarcodeValidation.IsValidEan(_code, 13);
                    break;
                case BarcodeFormat.ITF:
                    break;
                case BarcodeFormat.MAXICODE:
                    break;
                case BarcodeFormat.PDF_417:
                    break;
                case BarcodeFormat.QR_CODE:
                    break;
                case BarcodeFormat.RSS_14:
                    break;
                case BarcodeFormat.RSS_EXPANDED:
                    break;
                case BarcodeFormat.UPC_A:
                    break;
                case BarcodeFormat.UPC_E:
                    break;
                case BarcodeFormat.UPC_EAN_EXTENSION:
                    break;
                case BarcodeFormat.MSI:
                    break;
                case BarcodeFormat.PLESSEY:
                    break;
                case BarcodeFormat.IMB:
                    break;
                case BarcodeFormat.All_1D:
                    break;
                default:
                    break;
            }

            if (validCode)
            {
                ValidatedCode = _code;
                ValidatedSelectedFormat = _selectedFormat;
            }
            else
            {
                _error = $"Error al validar {SelectedFormat}. Revisa las reglas de dicho formato.";
            }

            OnPropertyChanged("Error");
        }
    }
}
