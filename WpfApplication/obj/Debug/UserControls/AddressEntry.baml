   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WpfApplication.UserControlsWpfApplication.UserControls  5      .    (WpfApplication.UserControls.AddressEntry   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WpfApplication.UserControls     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $	��200��6   $��* �6.    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Line 1:��6   $��0��6"   $��0��6/   �� 5   
   $��0��6N   $��1��6[   ��6   �� *Line1+ �� UpdateSourceTrigger$ PropertyChanged=�6[   �� 5   
   $��Line 2:��6   $��1��6"   $��0��6/   �� 5   
   $��1��6N   $��1��6[   ��6   �� *Line2+$ PropertyChanged=�6[   �� 5   
   $��City:��6   $��2��6    $��0��6-   �� 5   
   $��2��6M   $��1��6Z   ��6   �� *City+$ PropertyChanged=�6Z   �� 5    
   $��State:��6   $��3��6!   $��0��6.   �� 5!   
   $��3��6N   $��1��6[   ��6   �� *State+$ PropertyChanged=�6[   �� 5#   
   $
��Zip:��6   $��4��6   $��0��6,   �� 5$   
   $��4��6L   $��1��6Y   ��6   �� *Zip+$ PropertyChanged=�6Y   5%      5&      