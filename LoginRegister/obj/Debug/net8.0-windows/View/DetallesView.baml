   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5      A%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5      %    LoginRegister.View.DetallesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:LoginRegister.View     5      ;	viewmodel%clr-namespace:LoginRegister.ViewModel     5      .��5      � $��15q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Tabla��5         AutoGenerateColumns$ False��5      $��5q�5         CanUserResizeColumns$
 True��5         CanUserResizeRows$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5          MinRowHeight$ 30Q�5!      $	��300��5"      $��0��5#      $
��Auto=�5$      $
��Auto=�5%      ��5      �� *PagedDicatadores+ �� SelectedItem 5      �� *SelectedElement+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre��6%   
   Width$
 * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Nombre+6P   5*      �� 5-   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��0,10,0,0q�6X   .+�5.      �� $��⏮ Anterior��6   
���OO/�
�������$��5q�6�   $��5q�6�   ��6*   �� *PreviousPageCommand+6�   �� 5/      
�������$��Center=�6c   $
��10,0q�6~   ��6   �� *CurrentPage+ �� StringFormat$ Página {0}��6~   �� 50      $��/��6   
�������$��Center=�64   �� 51      
�������$��Center=�6\   $
��10,0q�6w   ��6   �� *
TotalPages+$
  {0}��6w   �� 52      $��Siguiente ⏭��6   
���OO/�
�������$��5q�6}   $��5q�6�   ��6+   �� *NextPageCommand+6�   53      �� 56   
   $��2��6    �� Padding$ 10q�6    �� CornerRadius$ 10��6+   
�������$��1q�6P   
�������._�57      �� .+�58      �� 
���   �$
��Bold"�6/   $��14(�6A   ��6O   �� *Dicatador.Id+$ ID: {0}���� 59      
���   �$��14(�6/   ��6=   �� *Dicatador.Name+$ Nombre: {0}���� 5:      
���   �$��14(�6/   ��6=   �� *Dicatador.Pais+$ 
País: {0}���� 5;      
���   �$��14(�6/   ��6=   �� *Dicatador.Description+$ Descripción: {0}���� 5>      $ Vertical=�6   $��10,15,10,10q�64   .+�5?      �� $��➕ Agregar Producto��6D   
��� d �
�������$��8q�6�   $��5q�6�   ��6   �� *AddProductoCommand+6�   �� 5@      $��🗑 Eliminar Producto��6G   
���  ��
�������$��8q�6�   $��5q�6�   ��6   �� *DeleteProductoCommand+6�   �� 5A      $��
❌ Cerrar��6   
�������
�������$��8q�6�   $��5q�6�   ��60   �� *DataContext.CloseCommand+ �� RelativeSource ��  �� AncestorType UserControl6�   5B      5C      5D      5F      5G      