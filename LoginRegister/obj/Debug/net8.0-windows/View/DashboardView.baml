   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5      A%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5	      &     LoginRegister.View.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:LoginRegister.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      6
viewmodels%clr-namespace:LoginRegister.ViewModel  5	         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design    
Background#  �   5        TextFillColorPrimaryBrush   
Foreground# �  5      $
��Auto��5      $
��Auto��5      .��5      � $��30q�6   $	��Top=�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $
��Left=�6;   $��10q�6V   .+�5        Wpf.Ui.Controls.Button  $��Agregar Producto��5      
���OO/�
�������$��40��5!      $	��180��5"      $��5q�5#      ��5      �� *AddProductoCommand+   Icon 5      '  !Wpf.Ui.Markup.SymbolIconExtension  *
Fluent24+5#        5%      $��Eliminar Producto��5'      
���  ��
�������$��40��5+      $	��180��5,      $��5q�5-      ��5&      �� *DeleteProductoCommand+ 5(        *
Fluent24+5-      5.        Wpf.Ui.Controls.DataGrid  51   
   -   5          Name$ Tabla��53      $��1��52      &   System.Windows.Controls.DataGrid   AutoGenerateColumns$
 True��56      $��	0,10,0,10q�57         CanUserResizeColumns$
 True��58         CanUserResizeRows$ False��59      	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 5:      $	��400��5;      $
��Auto=�5<      $
��Auto=�5=      
�������
   AlternatingRowBackground

 �����
�������$��1q�5A      ��54      �� *PagedDicatadores+ �� SelectedItem 55      �� *SelectedProducto+ � 	Resources 5D      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5E      "  6   .�5F      ��  � ��
 �   �63   �� 5G       � ��
 �����63   �� 5H       � ��$
 Bold"�63   �� 5I       � ��$
 10,5q�60   5J      5K      5M      �� 5P   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��10q�6X   .+�5Q      �� $��⮜ Anterior��6   
���   �
�������$
��10,5q�6x   ��6*   �� *PreviousPageCommand+6x   �� 5R      
�������$��Center=�6f   $
��10,0q�6�   ��6   �� *CurrentPage+ �� StringFormat$ Página {0} de��6�   �� 5S      
�������$��Center=�6G   $	��5,0q�6b   ��6   �� *
TotalPages+6b   �� 5T      $��Siguiente ⮞��6   
���   �
�������$
��10,5q�6u   ��6+   �� *NextPageCommand+6u   5U        5X   
   $��Logout��5Z      
���OO/�
�������$��30��5^      $	��100��5_      $��Right=�5`      $��2��5a      $��10q�5b      ��5Y      �� *LogoutCommand+ 5[        *
Fluent24+5b      5c      5d      