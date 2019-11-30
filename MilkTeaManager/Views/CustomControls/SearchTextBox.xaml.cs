﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MilkTeaManager.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for SearchTextBox.xaml
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        public SearchTextBox()
        {
            InitializeComponent();

            this.PART_TextBox.LostFocus += PART_TextBox_LostFocus;
            this.PART_TextBox.GotFocus += PART_TextBox_GotFocus;
        }

        private void PART_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.PART_ListBox.Visibility = Visibility.Visible;
        }

        private void PART_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.PART_ListBox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The source of the icon of <see cref="SearchTextBox"/>
        /// </summary>
        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        /// <summary>
        /// The text in the <see cref="SearchTextBox"/>
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// The selected item in the <see cref="SearchTextBox"/>
        /// </summary>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        /// <summary>
        /// Event occurs when the text property changed
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event TextChangedEventHandler TextChanged
        {
            add { PART_TextBox.TextChanged += value; }
            remove
            {
                PART_TextBox.TextChanged -= value;
            }
        }

        /// <summary>
        /// Event occurs when the selected item changed
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event SelectionChangedEventHandler SelectionChanged
        {
            add { PART_ListBox.SelectionChanged += value; }
            remove { PART_ListBox.SelectionChanged -= value; }
        }

        /// <summary>
        /// The hint text in the <see cref="SearchTextBox"/>
        /// </summary>
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        /// <summary>
        /// The height of the icon in <see cref="SearchTextBox"/>
        /// </summary>
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        /// <summary>
        /// The background of icon part in <see cref="SearchTextBox"/>
        /// </summary>
        public Brush IconBackground
        {
            get => (Brush)GetValue(IconBackgroundProperty);
            set => SetValue(IconBackgroundProperty, value);
        }

        /// <summary>
        /// The padding value of <see cref="TextBox"/> part 
        /// </summary>
        public Thickness TextBoxPadding
        {
            get => (Thickness)GetValue(TextBoxPaddingProperty);
            set => SetValue(TextBoxPaddingProperty, value);
        }

        /// <summary>
        /// The item source of <see cref="SearchTextBox"/>
        /// </summary>
        public object SearchBoxItemSource
        {
            get => (object)GetValue(SearchBoxItemSourceProperty);
            set => SetValue(SearchBoxItemSourceProperty, value);
        }

        /// <summary>
        /// The template of item in <see cref="SearchTextBox"/> source
        /// </summary>
        public DataTemplate SearchBoxItemTemplate
        {
            get => (DataTemplate)GetValue(SearchBoxItemTemplateProperty);
            set => SetValue(SearchBoxItemTemplateProperty, value);
        }

        /// <summary>
        /// The text displayed when the item source is null or empty
        /// </summary>
        public string EmptySourceText
        {
            get => (string)GetValue(EmptySourceTextProperty);
            set => SetValue(EmptySourceTextProperty, value);
        }

        /// <summary>
        /// The background of <see cref="ListBox"/> part in <see cref="SearchTextBox"/>
        /// </summary>
        public Brush SearchListBoxBackground
        {
            get => (Brush)GetValue(SearchListBoxBackgroundProperty);
            set => SetValue(SearchListBoxBackgroundProperty, value);
        }

        /// <summary>
        /// The height of <see cref="ListBox"/> part 
        /// </summary>
        public double ListBoxMaxHeight
        {
            get => (double)GetValue(ListBoxMaxHeightProperty);
            set => SetValue(ListBoxMaxHeightProperty, value);

        }

        /// <summary>
        /// Set the visibility of icon part
        /// </summary>
        public Visibility IconVisibility
        {
            get => (Visibility)GetValue(IconVisibilityProperty);
            set => SetValue(IconVisibilityProperty, value);
        }

        /// <summary>
        /// Set the style of PART_TextBox
        /// </summary>
        public Style TextBoxStyle
        {
            get => (Style)GetValue(TextBoxPaddingProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }


        /// <summary>
        /// The selected value to display in the <see cref="SearchTextBox"/>
        /// </summary>
        public object SelectedValue
        {
            get => GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        #region Dependency Properties
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
            "IconSource",
            typeof(ImageSource),
            typeof(SearchTextBox),
            new PropertyMetadata(null));


        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(SearchTextBox),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register(
            "Hint",
            typeof(string),
            typeof(SearchTextBox),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            "IconHeight",
            typeof(double),
            typeof(SearchTextBox));

        public static readonly DependencyProperty IconBackgroundProperty = DependencyProperty.Register(
            "IconBackground",
            typeof(Brush),
            typeof(SearchTextBox));

        public static readonly DependencyProperty TextBoxPaddingProperty = DependencyProperty.Register(
            "TextBoxPadding",
            typeof(Thickness),
            typeof(SearchTextBox),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty SearchBoxItemSourceProperty = DependencyProperty.Register(
            "SearchBoxItemSource",
            typeof(object),
            typeof(SearchTextBox));

        public static readonly DependencyProperty SearchBoxItemTemplateProperty = DependencyProperty.Register(
            "SearchBoxItemTemplate",
            typeof(DataTemplate),
            typeof(SearchTextBox));

        public static readonly DependencyProperty EmptySourceTextProperty = DependencyProperty.Register(
            "EmptySourceText",
            typeof(string),
            typeof(SearchTextBox),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SearchListBoxBackgroundProperty = DependencyProperty.Register(
            "SearchListBoxBackground",
            typeof(Brush),
            typeof(SearchTextBox),
            new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty ListBoxMaxHeightProperty = DependencyProperty.Register(
            "ListBoxMaxHeight",
            typeof(double),
            typeof(SearchTextBox));

        public static readonly DependencyProperty IconVisibilityProperty = DependencyProperty.Register(
            "IconVisibility",
            typeof(Visibility),
            typeof(SearchTextBox));

        public static readonly DependencyProperty TextBoxStyleProperty = DependencyProperty.Register(
            "TextBoxStyle",
            typeof(Style),
            typeof(SearchTextBox));

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue",
            typeof(object),
            typeof(SearchTextBox));

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem",
            typeof(object),
            typeof(SearchTextBox));

        #endregion

    }
}
