   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5      A%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5      7 clr-namespace:LoginRegister.ViewLoginRegister.View  5      (    "LoginRegister.View.InformacionView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:LoginRegister.View     5      ;	viewmodel%clr-namespace:LoginRegister.ViewModel     5      1view clr-namespace:LoginRegister.View     5      $	��500��5      $	��800��6     � 	Resources  5       �� DataType/   )LoginRegister.ViewModel.DetallesViewModel%   LoginRegister.View.DetallesView��%G   (��       5      *, +)�� 6
   "  6   .R�5        5      5      .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��320 �6   .+�5$   
   �� $��Agregar Pedido��5&      
���OO/�
�������$
��Bold"�5)      $��40��5*      $	��180��5+      $��10q�5,      $
��Left=�5-      $��Center=�5.      $��10q�5/      ��5%      �� *AddPedidoCommand+5/      �� 51   
   $��🗑 Eliminar Pedido��69   
���  ��$	��180��6k   $��40��6w   
�������$��8q�6�   $��214,10,56,10q�6�   ��6   �� *DeletePedidoCommand+6�   �� 54   
   $��1��6   $��5q�6$   .��55      �� $��5q�69   ��6   �� *Items+��56      �� 57      .R�58      �  � Orientation$ 
Horizontal=�6$   59      ��5<      �� 5=      .R�5>      �� $��8q�6!    �� Padding$ 10q�6,    �� CornerRadius$ 15��69   
�������$��1q�6^   
�������._�5?      �� $��Center=�6)   .+�5A   "   �� $��80��6)   $��80��65   $
��📦��5D   )   $��20(�5E   )   
�������
�������$��0q�5H   )    � Cursor$
 Hand��5I   )    � ToolTip$ Seleccionar Pedido��5J   )   ��5B   )   �� *$"DataContext.SelectViewModelCommand+	 �� RelativeSource	 �� 
 �� AncestorType
 UserControl��5C   )   �� *Id+5J   )   �� 5M   "   
���   �$
��Bold"�6n   $��Center=�6�   ��6?   �� *Id+ �� StringFormat$ 
Pedido {0}��6�   �� 5N   "   
���   �$��12(�6|   $��Center=�6�   ��6?   �� *Fecha+$ Fecha: {0:dd/MM/yyyy}��6�   �� 5O   "   
���   �$��12(�6u   $��Center=�6�   ��6?   �� *	Usuario+$ Usuario: {0}��6�   �� 5P   "   
���   �$��12(�6   $
��Bold"�6�   $��Center=�6�   ��6?   �� *Productos.Count+$ Productos: {0}��6�   5Q      5R      5S      5U      5V      �� 5Y   
   $��1��6   $��2��6!   ���#67BF6A$ 10q�6G   $ 10��6T   
�������$��1q�6y   ._�5Z      �� ��6   �� *SelectedViewModel+5[      5\      5]      