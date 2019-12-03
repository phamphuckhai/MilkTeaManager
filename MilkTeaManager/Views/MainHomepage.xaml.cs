﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MilkTeaManager
{
    /// <summary>
    /// Interaction logic for MainHomepage.xaml
    /// </summary>
    public partial class MainHomepage : Window
    {
        public MainHomepage()
        {
            InitializeComponent();
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.PAGE_CONTENT.NavigationService.Navigate(new Uri("Views/Pages/RevenueStatistic.xaml", UriKind.RelativeOrAbsolute));
        }

        private bool _allowDirectNavigation = false;
        private NavigatingCancelEventArgs _navArgs = null;
        private Duration _duration = new Duration(TimeSpan.FromSeconds(0.5));
        private double _oldHeight = 0;

        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Content != null && !_allowDirectNavigation)
            {
                e.Cancel = true;

                _navArgs = e;
                _oldHeight = this.PAGE_CONTENT.ActualHeight;

                DoubleAnimation animation0 = new DoubleAnimation();
                animation0.From = this.PAGE_CONTENT.ActualHeight;
                animation0.To = 0;
                animation0.Duration = _duration;
                animation0.Completed += SlideCompleted;
                this.PAGE_CONTENT.BeginAnimation(HeightProperty, animation0);
            }
            _allowDirectNavigation = false;
        }

        private void SlideCompleted(object sender, EventArgs e)
        {
            _allowDirectNavigation = true;
            switch (_navArgs.NavigationMode)
            {
                case NavigationMode.New:
                    if (_navArgs.Uri == null)
                        this.PAGE_CONTENT.Navigate(_navArgs.Content);
                    else
                        this.PAGE_CONTENT.Navigate(_navArgs.Uri);
                    break;
                case NavigationMode.Back:
                    this.PAGE_CONTENT.GoBack();
                    break;
                case NavigationMode.Forward:
                    this.PAGE_CONTENT.GoForward();
                    break;
                case NavigationMode.Refresh:
                    this.PAGE_CONTENT.Refresh();
                    break;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                (ThreadStart)delegate ()
                {
                    DoubleAnimation animation0 = new DoubleAnimation();
                    animation0.From = 0;
                    animation0.To = _oldHeight;
                    animation0.Duration = _duration;
                    this.PAGE_CONTENT.BeginAnimation(HeightProperty, animation0);
                });
        }
        private void MainFrame_OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.5);
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            if (e.NavigationMode == NavigationMode.New)
            {
                ta.From = new Thickness(500, 0, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 500, 0);
            }
            this.PAGE_CONTENT.BeginAnimation(MarginProperty, ta);
        }
        private void RadioButton_Click_Thu(object sender, RoutedEventArgs e)
        {
            this.PAGE_CONTENT.NavigationService.Navigate(new Uri("Views/Pages/RevenueStatistic.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadioButton_Click_Chi(object sender, RoutedEventArgs e)
        {
            this.PAGE_CONTENT.NavigationService.Navigate(new Uri("Views/Pages/ExpenditureStatistic.xaml", UriKind.RelativeOrAbsolute));
        }
        private void RadioButton_Click_BCNL(object sender, RoutedEventArgs e)
        {
            this.PAGE_CONTENT.NavigationService.Navigate(new Uri("Views/Pages/MaterialReport.xaml", UriKind.RelativeOrAbsolute));
        }
        private void RadioButton_Click_BCTonKho(object sender, RoutedEventArgs e)
        {
            this.PAGE_CONTENT.NavigationService.Navigate(new Uri("Views/Pages/InventoryReport.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
