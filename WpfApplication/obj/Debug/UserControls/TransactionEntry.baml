   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WpfApplication.UserControlsWpfApplication.UserControls  5      E'clr-namespace:WpfApplication.ViewModelsWpfApplication.ViewModels  5      2    ,WpfApplication.UserControls.TransactionEntry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WpfApplication.UserControls     5      6vm'clr-namespace:WpfApplication.ViewModels     5      $	��300��5	      .��5      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Date:��6   $��0��6    $��0��6-   (  "System.Windows.Controls.DatePicker  5   
   $��0��6   $��1��6"      SelectedDate 62   �� *
Model.Date+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��From:��6   $��1��6    $��0��6-   �� 5   
   $��1��6   $��1��6     �� DisplayMemberPath$
 Name��6b    �� SelectedValuePath$ Id��6{   ��60   �� *FromAccounts+ �� Mode$ OneWay=� �� SelectedValue 6�   �� *FromAccountId+�� 5   
   $	��To:��6   $��2��6   $��0��6+   �� 5    
   $��2��6   $��1��6    $
 Name��6`   $ Id��6y   ��60   �� *
ToAccounts+$ OneWay=� 6�   �� *ToAccountId+�� 5"   
   $��Memo:��6   $��3��6    $��0��6-   �� 5#   
   $��3��6S   $��1��6`   ��6   �� *
Model.Memo+$ PropertyChanged=�6`   &   System.Windows.Controls.DataGrid  5%   
      AutoGenerateColumns .  $��4��6c   $��0��6p   $��2��6�   	   CanUserAddRows	 . 
   CanUserDeleteRows
 . ��6   �� *TransactionEntryLineItemVMs+   Columns 5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Product��6)      CellTemplate 5(      �� 5)      .R�5*      �� $
 Name��6�   $ Id��6�   ��6'   �� *0.DataContext.MainWindowVM.Repository.Categories+$ OneWay=� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >� 6  �� *	ProductId+5+      5-      0  *System.Windows.Controls.DataGridTextColumn  5.      $ 	Reference��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	Reference+$ PropertyChanged=�  5/      $ Amount��6%    65   �� *Amount+$ PropertyChanged=� �� StringFormat$ c2��51      �� 53   
   $��Total:��6   $��5��6!   $��0��6.   �� 54   
   $��7��66   $��1��6C    �� 
IsReadOnly . ��6   �� *Total+$ OneWay=�6S   55      56      