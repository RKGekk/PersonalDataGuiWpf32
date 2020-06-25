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
    
    public partial class DictionaryWindow : Window {

        private class LoadingTreeViewItem { }

        private TypeRepository _typeRepository = new TypeRepository();

        public DictionaryWindow() {
            InitializeComponent();
        }

        public void UpdateFields(TypeDigest type) {
            this.TextBoxIdParent.Text = type.ParentId.HasValue ? type.ParentId.ToString() : "" ;
            this.TextBoxTypeCategoryId.Text = type.TypeCategoryId.ToString();
            this.TextBoxCode.Text = type.Code.ToString();
            this.TextBoxSCode.Text = type.BCode != null ? type.BCode.ToString() : "";
            this.TextBoxSName.Text = type.Name != null ? type.Name.ToString() : "";
            this.TextBoxTableId.Text = type.TypeTableId.HasValue ? type.TypeTableId.ToString() : "";
            this.TextBoxSNote.Text = type.Note != null ? type.Note.ToString() : "";
            this.TextBoxOpenDate.Text = type.Open.ToString();
            this.TextBoxCloseDate.Text = type.Close.ToString();
            this.TextBoxOrder.Text = type.Order.ToString();
        }

        private void CategoryTree_Initialized(object sender, EventArgs e) {
            var this_tree_view = (TreeView)sender;
            _typeRepository.GetRootCategoryTypeDigest().Match(
                None: () => {
                    this_tree_view.Items.Add(CreateCategoryTreeViewItem("No Categories(Empty)", null));
                    return Unit();
                },
                Some: rootTypeDigest => {
                    this_tree_view.Items.Add(CreateCategoryTreeViewItem(rootTypeDigest.Code, rootTypeDigest));
                    return Unit();
                }
            );
        }

        private TreeViewItem CreateCategoryTreeViewItem(string headerTitle, object data) {

            TreeViewItem item = new TreeViewItem();
            item.Header = headerTitle;
            item.Tag = data;
            item.ContextMenu = (ContextMenu)this.Resources["CategoryTreeViewContextMenu"];
            item.MouseDown += CategoryTreeViewItem_MouseDown;
            item.Selected += CategoryItem_Selected;

            TreeViewItem fakeChildItem = new TreeViewItem();
            fakeChildItem.Header = "Loading...";
            fakeChildItem.Tag = new LoadingTreeViewItem();

            item.Items.Add(fakeChildItem);
            return item;
        }

        private TreeViewItem CreateTypeDigestTreeViewItem(string headerTitle, object data) {

            TreeViewItem item = new TreeViewItem();
            item.Header = headerTitle;
            item.Tag = data;
            item.ContextMenu = (ContextMenu)this.Resources["TypeTreeViewContextMenu"];
            item.MouseDown += CategoryTreeViewItem_MouseDown;
            item.Selected += DictionaryItem_Selected;

            TreeViewItem fakeChildItem = new TreeViewItem();
            fakeChildItem.Header = "Loading...";
            fakeChildItem.Tag = new LoadingTreeViewItem();

            item.Items.Add(fakeChildItem);
            return item;
        }

        private void CategoryItem_Selected(object sender, RoutedEventArgs e) {

            TreeViewItem this_TreeViewItem = e.Source as TreeViewItem;
            TypeDigest categoryTypeDigest = (TypeDigest)this_TreeViewItem.Tag;
            UpdateFields(categoryTypeDigest);
            DictionaryTree.Items.Clear();
            foreach (TypeDigest dictionaryTypeDigest in _typeRepository.GetTypeDigestsByCategory(categoryTypeDigest.Id)) {
                if (dictionaryTypeDigest.ParentId == null) {
                    DictionaryTree.Items.Add(CreateTypeDigestTreeViewItem(dictionaryTypeDigest.Code, dictionaryTypeDigest));
                }
            }
        }

        private void DictionaryItem_Selected(object sender, RoutedEventArgs e) {

            TreeViewItem this_TreeViewItem = e.Source as TreeViewItem;
            TypeDigest typeDigest = (TypeDigest)this_TreeViewItem.Tag;
            UpdateFields(typeDigest);
        }

        private void CategoryTreeViewItem_MouseDown(object sender, MouseButtonEventArgs e) {
            var this_TreeViewItem = e.Source as TreeViewItem;
            if (e.ChangedButton == MouseButton.Right) {
                this_TreeViewItem.IsSelected = true;
            };
        }

        private void CategoryTree_Expanded(object sender, RoutedEventArgs e) {
            TreeViewItem this_TreeViewItem = e.Source as TreeViewItem;
            TypeDigest parentCategoryTypeDigest = (TypeDigest)this_TreeViewItem.Tag;
            if (this_TreeViewItem.Items.Count > 0 && this_TreeViewItem.Items[0] is TreeViewItem && ((TreeViewItem)this_TreeViewItem.Items[0]).Tag is LoadingTreeViewItem) {
                this_TreeViewItem.Items.Clear();
                foreach (TypeDigest childTypeDigest in _typeRepository.GetTypeDigestsByParent(parentCategoryTypeDigest.Id)) {
                    this_TreeViewItem.Items.Add(CreateCategoryTreeViewItem(childTypeDigest.Code, childTypeDigest));
                }
            }
        }

        private void DictionaryTree_Expanded(object sender, RoutedEventArgs e) {
            TreeViewItem this_TreeViewItem = e.Source as TreeViewItem;
            TypeDigest typeDigest = (TypeDigest)this_TreeViewItem.Tag;
            if (this_TreeViewItem.Items.Count > 0 && this_TreeViewItem.Items[0] is TreeViewItem && ((TreeViewItem)this_TreeViewItem.Items[0]).Tag is LoadingTreeViewItem) {
                this_TreeViewItem.Items.Clear();
                foreach (TypeDigest childTypeDigest in _typeRepository.GetTypeDigestsByParent(typeDigest.Id)) {
                    this_TreeViewItem.Items.Add(CreateTypeDigestTreeViewItem(childTypeDigest.Code, childTypeDigest));
                }
            }
        }

        private void CategoryMenuItemInsert_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = CategoryTree.SelectedItem as TreeViewItem;

            int parentId = (selectedItem.Tag as TypeDigest).Id;
            int categoryId = _typeRepository.GetRootCategoryTypeDigest().Match(
                None: () => -1,
                Some: t => t.Id
            );

            TypeDigestViewModel viewModel = new TypeDigestViewModel(new TypeDigest() {
                ParentId = parentId,
                TypeCategoryId = categoryId,
                Edit = DateTime.Now,
                Open = DateTime.Now,
                Close = new DateTime(2100, 1, 1)
            });

            TypeDigestInsertWindow typeDigestInsertWindow = new TypeDigestInsertWindow();
            typeDigestInsertWindow.ViewModel = viewModel;
            typeDigestInsertWindow.Show();
        }

        private void ButtonRefreshCategory_Click(object sender, RoutedEventArgs e) {
            var this_tree_view = CategoryTree;
            this_tree_view.Items.Clear();
            _typeRepository.GetRootCategoryTypeDigest().Match(
                None: () => {
                    this_tree_view.Items.Add(CreateCategoryTreeViewItem("No Categories(Empty)", null));
                    return Unit();
                },
                Some: rootTypeDigest => {
                    this_tree_view.Items.Add(CreateCategoryTreeViewItem(rootTypeDigest.Code, rootTypeDigest));
                    return Unit();
                }
            );
        }

        private void CategoryMenuItemDelete_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = CategoryTree.SelectedItem as TreeViewItem;
            TypeDigest typeDigest = (TypeDigest)selectedItem.Tag;

            _typeRepository.DeleteTypeDigest(typeDigest);
        }

        private void TypeDigestInsertMenuItem_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = DictionaryTree.SelectedItem as TreeViewItem;
            TypeDigest currentType = selectedItem.Tag as TypeDigest;

            TypeDigestViewModel viewModel = new TypeDigestViewModel(new TypeDigest() {
                ParentId = currentType.ParentId,
                TypeCategoryId = currentType.TypeCategoryId,
                Edit = DateTime.Now,
                Open = DateTime.Now,
                Close = new DateTime(2100, 1, 1)
            });

            TypeDigestInsertWindow typeDigestInsertWindow = new TypeDigestInsertWindow();
            typeDigestInsertWindow.ViewModel = viewModel;
            typeDigestInsertWindow.Show();
        }

        private void RefreshDictionaryButton_Click(object sender, RoutedEventArgs e) {

            TypeDigest categoryTypeDigest = (TypeDigest)(CategoryTree.SelectedItem as TreeViewItem).Tag;
            DictionaryTree.Items.Clear();
            foreach (TypeDigest dictionaryTypeDigest in _typeRepository.GetTypeDigestsByCategory(categoryTypeDigest.Id)) {
                if (dictionaryTypeDigest.ParentId == null) {
                    DictionaryTree.Items.Add(CreateTypeDigestTreeViewItem(dictionaryTypeDigest.Code, dictionaryTypeDigest));
                }
            }
        }

        private void AddTypeButton_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = CategoryTree.SelectedItem as TreeViewItem;
            TypeDigest typeCategoryDigest = (TypeDigest)selectedItem.Tag;

            TypeDigestViewModel viewModel = new TypeDigestViewModel(new TypeDigest() {
                TypeCategoryId = typeCategoryDigest.Id,
                Edit = DateTime.Now,
                Open = DateTime.Now,
                Close = new DateTime(2100, 1, 1)
            });

            TypeDigestInsertWindow typeDigestInsertWindow = new TypeDigestInsertWindow();
            typeDigestInsertWindow.ViewModel = viewModel;
            typeDigestInsertWindow.Show();
        }

        private void CategoryTypeDigestInsertMenuItem_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = CategoryTree.SelectedItem as TreeViewItem;
            TypeDigest categoryType = selectedItem.Tag as TypeDigest;

            TypeDigestViewModel viewModel = new TypeDigestViewModel(new TypeDigest() {
                TypeCategoryId = categoryType.Id,
                Edit = DateTime.Now,
                Open = DateTime.Now,
                Close = new DateTime(2100, 1, 1)
            });

            TypeDigestInsertWindow typeDigestInsertWindow = new TypeDigestInsertWindow();
            typeDigestInsertWindow.ViewModel = viewModel;
            typeDigestInsertWindow.Show();
        }

        private void TypeDigestInsertSubMenuItem_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = DictionaryTree.SelectedItem as TreeViewItem;
            TypeDigest currentType = selectedItem.Tag as TypeDigest;

            TypeDigestViewModel viewModel = new TypeDigestViewModel(new TypeDigest() {
                ParentId = currentType.Id,
                TypeCategoryId = currentType.TypeCategoryId,
                Edit = DateTime.Now,
                Open = DateTime.Now,
                Close = new DateTime(2100, 1, 1)
            });

            TypeDigestInsertWindow typeDigestInsertWindow = new TypeDigestInsertWindow();
            typeDigestInsertWindow.ViewModel = viewModel;
            typeDigestInsertWindow.Show();
        }

        private void TypeDigestDeleteMenuItem_Click(object sender, RoutedEventArgs e) {

            TreeViewItem selectedItem = DictionaryTree.SelectedItem as TreeViewItem;
            TypeDigest typeDigest = (TypeDigest)selectedItem.Tag;

            _typeRepository.DeleteTypeDigest(typeDigest);
        }
    }
}
