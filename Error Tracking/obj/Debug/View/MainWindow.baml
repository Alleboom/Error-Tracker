   M S B A M L   `   `   `  ����I  EError Tracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Error_Tracking.ViewModelError_Tracking.ViewModel  5   	   $    Error_Tracking.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <	ViewModel&clr-namespace:Error_Tracking.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��700��6)    � DataContext 5      ,   &Error_Tracking.ViewModel.MainViewModel  5   
   .��5	      �  � RowDefinitions 5
   
   �� 5      $��22 �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   o� $��0��6   $��2��6   
�������.@�5      m� $��_File��6   .@�5      m� $��_Exit��6   5      m� 5      $��	_Software��6   .@�5      m� $��_Add...��6    m� CommandParameter$ AddNewSoftware��6O    m� Command 6,   �� *NewPageCommand+6O   m� 5      $��_Edit...��6   $ EditSoftware��6P    6-   �� *NewPageCommand+6P   m� 5      $��
_Remove...��6   $ RemoveSoftware��6R    6/   �� *NewPageCommand+6R   5      m� 5      $��_Error��6   .@�5      m� $��_Add...��6   $ AddNewError��6O    6,   �� *NewPageCommand+6O   m� 5      $��_Edit...��6   $ 	EditError��6P    6-   �� *NewPageCommand+6P   m� 5      $��
_Remove...��6   $ RemoveError��6R    6/   �� *NewPageCommand+6R   5       5"      �� 5#   
   $��0��6   
�������$��1��6;   .+�5$      �� $��Search by Software Name:��6   $��5q�67   �� 5%      $��5,0,5,0q�6    �� DisplayMemberPath$
 Name��6�    �� SelectedItem 6(   �� *SelectedSoftware+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���6�   �� *SoftwareList+6�   �� 5&      $��Search��6   $��5,20,5,3q�6&   $�� ��6S   ��68   �� *Search+6S   5'      ]� 5)   
   $��1��6   $��1��6$   .+�5*      �� $��2,2,1,2q�6   $ Description��6W   $	��200��6w   ��61   �� *SearchResults+6w   �� 5+      $��1,2,2,2q�6   $ 
Resolution��6W   ��61   �� *SearchResults+6W   5,      5.      5/      