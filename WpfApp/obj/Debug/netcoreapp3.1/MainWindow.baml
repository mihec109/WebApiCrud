   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��197* �6   �� 5      $
��237* �6    � ColumnDefinitions 5   
   �� 5      $	��93* �6   �� 5      $
��307* �6   �� 5      $
��400* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	datagrid1��5   %      
IsReadOnly$
 True��6      AutoGenerateColumns$
 True��68   $��	0,31,10,0q�6S   $��3��6�   $	��332��6�   $	��Top=�6�   $��Right=�6�   $	��780��6�   $��2��6�   �� 5   
   -   5        $��Refresh��5      $
��Left=�6#   $��	10,0,0,14q�6>   $��Bottom=�6Q   $��35��6l   $��88��6x   $��1��6�   $��2��6�   �� 5   
   -   5        $	��Add��5      $
��Left=�6   $��	77,0,0,14q�6:   $��Bottom=�6M   $��35��6h   $��88��6t   $��1��6�   $��1��6�   �� 5   
   -   5        $��Update��5      $
��Left=�6"   $��
237,0,0,14q�6=   $��Bottom=�6Q   $��35��6l   $��88��6x   $��2��6�   $��1��6�   $��1��6�   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��	90,0,0,14q�6=   $��Bottom=�6P   $��35��6k   $��88��6w   $��2��6�   $��1��6�   �� 5   
   -   5        $��Deselect��5      $
��Left=�6$   $��14,6,0,0q�6?   $	��Top=�6Q   6i   �� 5   
   -   5        $
��Exit��5      $
��Left=�6    $��	344,0,0,9q�6;   $��Bottom=�6N   $��40��6i   $��46��6u   $��2��6�   $��1��6�   5      5      