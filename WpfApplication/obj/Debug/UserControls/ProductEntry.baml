   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WpfApplication.UserControlsWpfApplication.UserControls  5      .    (WpfApplication.UserControls.ProductEntry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WpfApplication.UserControls     5      .��5      �   � ColumnDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   $	��200��6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Name:��6   $��0��6    $��0��60   �� 5   
   $��1��6S   $��0��6c   ��6   �� *
Model.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5   
   $��Description:��6   $��0��6'   $��1��67   �� 5   
   $��1��6Z   $��1��6j   ��6   �� *Model.Description+$ PropertyChanged=�6j   �� 5   
   $��	Category:��6   $��2��6$   $��0��61   �� 5   
    �� DisplayMemberPath$
 Name��6N    �� SelectedValuePath$ Id��6g   $��2��6�   $��1��6�   ��6   �� *$"MainWindowVM.Repository.Categories+ �� SelectedValue 6~   �� *Model.CategoryId+$ PropertyChanged=�6�   5      5      