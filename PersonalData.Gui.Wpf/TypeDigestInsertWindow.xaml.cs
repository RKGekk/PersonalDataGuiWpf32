using ModelAssistant;
using PersonalData.Repository;
using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unit = System.ValueTuple;
using static ModelAssistant.F;
using PersonalData.Gui.Wpf.ViewModel;

namespace PersonalData.Gui.Wpf {

    public partial class TypeDigestInsertWindow : Window {

        private TypeRepository _typeRepository = new TypeRepository();

        public TypeDigestViewModel ViewModel { get; set; }

        public TypeDigestInsertWindow() {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e) {
            MainGrid.DataContext = ViewModel;
        }

        private void ButtonParentIdCheck_Click(object sender, RoutedEventArgs e) {

            int? idParent = ViewModel.ParentId;
            if (idParent.HasValue) {
                _typeRepository.GetTypeDigest(idParent.Value).Match(
                    None: () => {
                        EllopseParentId.Fill = Brushes.Red;
                        return Unit();
                    },
                    Some: t => {
                        EllopseParentId.Fill = Brushes.Green;
                        TextBlockIdParent.Text = t.Code + "(" + t.Name + ")";
                        return Unit();
                    }
                );
            }
            else {
                if (ViewModel.TypeCategoryId.HasValue && ViewModel.TypeCategoryId.Value == _typeRepository.GetRootCategoryTypeDigest().Match(() => -1, t => t.Id)) {
                    EllopseParentId.Fill = Brushes.Red;
                }
                else {
                    EllopseParentId.Fill = Brushes.Green;
                }
            }

            e.Handled = true;
        }

        private void ButtonCategoryIdCheck_Click(object sender, RoutedEventArgs e) {

            int? idTypeCategory = ViewModel.TypeCategoryId;
            if (idTypeCategory.HasValue) {
                _typeRepository.GetTypeDigest(idTypeCategory.Value).Match(
                    None: () => {
                        EllipseIdTypeCategory.Fill = Brushes.Red;
                        return Unit();
                    },
                    Some: t => {
                        EllipseIdTypeCategory.Fill = Brushes.Green;
                        TextBlockidTypeCategory.Text = t.Code + "(" + t.Name + ")";
                        return Unit();
                    }
                );
            }
            else {
                EllipseIdTypeCategory.Fill = Brushes.Red;
            }

            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            string code = ViewModel.Code;
            if (code != null && code.Length > 0) {
                _typeRepository.GetTypeDigest(code).Match(
                    None: () => {
                        EllipseCode.Fill = Brushes.Green;
                        return Unit();
                    },
                    Some: t => {
                        EllipseCode.Fill = Brushes.Red;
                        TextBlockCode.Text = t.Code + "(" + t.Name + ")";
                        return Unit();
                    }
                );
            }
            else {
                EllipseCode.Fill = Brushes.Red;
            }

            e.Handled = true;
        }

        private void ButtonTableIdCheck_Click(object sender, RoutedEventArgs e) {

            int? idTypeTable = ViewModel.TypeTableId;
            if (idTypeTable.HasValue) {
                _typeRepository.GetTypeTable(idTypeTable.Value).Match(
                    None: () => {
                        EllipseTableId.Fill = Brushes.Red;
                        return Unit();
                    },
                    Some: t => {
                        EllipseTableId.Fill = Brushes.Green;
                        TextBlockTableId.Text = t.Table + "(" + t.Name + ")";
                        return Unit();
                    }
                );
            }
            else {
                EllipseTableId.Fill = Brushes.Green;
            }

            e.Handled = true;
        }

        private void ButtonAddToDB_Click(object sender, RoutedEventArgs e) {

            _typeRepository.InsertTypeDigest(ViewModel.TypeDigest);
            e.Handled = true;
            this.Close();
        }

        private void ButtonOpenDateToday_Click(object sender, RoutedEventArgs e) {
            ViewModel.Open = DateTime.Now;
        }

        private void ButtonCloseDateToday_Click(object sender, RoutedEventArgs e) {
            ViewModel.Close = DateTime.Now;
        }

        private void ButtonCloseDateEnd_Click(object sender, RoutedEventArgs e) {
            ViewModel.Close = new DateTime(2100, 1, 1);
        }
    }
}
