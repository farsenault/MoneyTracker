   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WpfApplication.ViewModelsWpfApplication.ViewModels  5      ;    5WpfApplication.UserControls.TransactionFrequencyEntry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6vm'clr-namespace:WpfApplication.ViewModels     5      $	��300��5        � DataContext  5
      ;   5WpfApplication.ViewModels.TransactionFrequencyEntryVM  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��	Interval:��6   $��0��6$   $��0��61   �� 5   
   -   5         ��Name$ internal��5      $��0��6%   $��1��62    �� DisplayMemberPath$ Description��6f    �� SelectedValuePath$ Id��6�   ��6B   �� *Frequencies+ �� SelectedValue 6�   �� *SelectedFrequencyId+�� 5   
   $��
Frequency:��6   $��1��6%   $��0��62   �� 5   
   $��1��6u   $��1��6�   ��6   �� *SelectedItem.Frequency+ �� UpdateSourceTrigger$ PropertyChanged=� �� ElementName$ internal��6�   �� 5    
   $��Begin Date:��6   $��2��6&   $��0��63   (  "System.Windows.Controls.DatePicker  5!   
   $��2��6   $��1��6"   	   SelectedDate	 62   �� *SelectedItem.BeginDate+$ PropertyChanged=�$ internal���� 5#   
   $��	End Date:��6   $��3��6$   $��0��61     5$   
   $��3��6   $��1��6"   	 62   �� *SelectedItem.EndDate+$ PropertyChanged=�$ internal��5%      5&      