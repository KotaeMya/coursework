   M S B A M L   `   `   `  ����H  DcourseworkWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:courseworkWPFcourseworkWPF  5   	       courseworkWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:courseworkWPF     5   	     � Title$  
MainWindow��5   	   $	��454��6   $	��453��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ btnCreateSynch��5   .   $��0��6   $��0��6!   $	��130��6F   .��5      �� $
��Wrap=�6   $��14(�6,   $+��%Новая синхронизация��6:   5      �� 5   
   -   5        $ btnDeleteSynch��5   .   $��0��6   $��1��6!   $	��130��6F   .��5      �� $
��Wrap=�6   $��14(�6,   $/��)Удалить синхронизацию��6;   5      �� 5   
   -   5        $ btnEventsLog��5   .   $��0��6   $��2��6!   $	��130��6D   .��5      �� $
��Wrap=�6   $��14(�6,   $!��Список событий��6;   5      �� 5!   
   -   5         ��Name$ FoldersList��5!   #   $��4��6   $��1��68   ��6H   �� *	Folders+��5"      �� 5#      .R�5$      �� $��5q�6!   .+�5%      �� $��18(�6$   ��62   �� *
FolderFrom+�� 5&      ��6$   �� *
FolderTo+5'      5(      5*      5+      5,      