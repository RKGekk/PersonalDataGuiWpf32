using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.ViewModel {

    public class TypeDigestViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public TypeDigest TypeDigest { get; }

        public TypeDigestViewModel(TypeDigest typeDigest) {
            TypeDigest = typeDigest;
            TypeDigest.ParentId = ParentId;
            TypeDigest.TypeCategoryId = TypeCategoryId;
            TypeDigest.Code = Code;
            TypeDigest.BCode = BCode;
            TypeDigest.Name = Name;
            TypeDigest.TypeTableId = TypeTableId;
            TypeDigest.Note = Note;
            TypeDigest.Open = Open;
            TypeDigest.Close = Close;
            TypeDigest.Order = Order;
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }

        public int? ParentId {
            get => TypeDigest.ParentId;
            set {
                TypeDigest.ParentId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ParentId"));
            }
        }

        public int? TypeCategoryId {
            get => TypeDigest.TypeCategoryId;
            set {
                TypeDigest.TypeCategoryId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TypeCategoryId"));
            }
        }

        public string Code {
            get => TypeDigest.Code;
            set {
                TypeDigest.Code = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Code"));
            }
        }

        public string BCode {
            get => TypeDigest.BCode;
            set {
                TypeDigest.BCode = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BCode"));
            }
        }

        public string Name {
            get => TypeDigest.Name;
            set {
                TypeDigest.Name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        public int? TypeTableId {
            get => TypeDigest.TypeTableId;
            set {
                TypeDigest.TypeTableId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TypeTableId"));
            }
        }

        public string Note {
            get => TypeDigest.Note;
            set {
                TypeDigest.Note = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Note"));
            }
        }

        public DateTime Open {
            get => TypeDigest.Open;
            set {
                TypeDigest.Open = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Open"));
            }
        }

        public DateTime Close {
            get => TypeDigest.Close;
            set {
                TypeDigest.Close = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Close"));
            }
        }

        public int Order {
            get => TypeDigest.Order;
            set {
                TypeDigest.Order = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Order"));
            }
        }
    }
}
