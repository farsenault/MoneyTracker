   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WpfApplication.UserControlsWpfApplication.UserControls  5      E'clr-namespace:WpfApplication.ViewModelsWpfApplication.ViewModels  5      .    (WpfApplication.UserControls.AccountEntry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WpfApplication.UserControls     5      6vm'clr-namespace:WpfApplication.ViewModels     5      $	��300��5	      .��5      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Parent Account:��6   $��0��6*   $��0��67   �� 5   
    �� DisplayMemberPath$
 Name��6L    �� SelectedValuePath$ Id��6e   $��0��6�   $��1��6�   ��6   �� *" MainWindowVM.Repository.Accounts+ �� SelectedValue 6|   �� *Model.ParentAccountId+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Name:��6   $��1��6    $��0��6-   �� 5   
   $��1��6S   $��1��6`   ��6   �� *
Model.Name+$ PropertyChanged=�6`   �� 5!   
   $��Type:��6   $��2��6    $��0��6-   �� 5"   
   $��2��6S   $��1��6`   ��6   �� *
Model.Type+$ PropertyChanged=�6`   �� 5$   
   $��Phone:��6   $��3��6!   $��0��6.   �� 5%   
   $��3��6T   $��1��6a   ��6   �� *Model.Phone+$ PropertyChanged=�6a   �� 5'   
   $��Email:��6   $��4��6!   $��0��6.   �� 5(   
   $��4��6T   $��1��6a   ��6   �� *Model.Email+$ PropertyChanged=�6a   �� 5*   
   $��Website:��6   $��5��6#   $��0��60   �� 5+   
   $��5��6V   $��1��6c   ��6   �� *Model.Website+$ PropertyChanged=�6c   �� 5-   
   $��Address��6   $��6��6"   $��0��6/   $��2��6?   $��Center=�6S   .   (WpfApplication.UserControls.AddressEntry  5/   
   $��7��6C   $��0��6P   $��2��6`    � DataContext 6   �� *Model.Address+6`   50      51      