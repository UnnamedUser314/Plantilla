   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5      %    LoginRegister.View.RegistroView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      6
viewmodels%clr-namespace:LoginRegister.ViewModel  5      $
��auto��5      $
��auto��6   ��5      �� 5   
     �� ImageSource$  /Resources/GreenBG.png��6    j� Stretch$ UniformToFill=�6:   .��5      � $��Center=�6   $��Center=�6&   .+�5   
   ��  �� Padding$ 30q�5       �� CornerRadius$ 15��5      
����������#4A90E2$��2q�5      $	��350��5      $��Center=�5       J� Opacity$
 0.95Q�5      ._�5      �� $��Center=�6   $��Center=�64   .+�5!      �� $��Registro de Usuario��5"      $��26(�5#      $
��Bold"�5$      
���   �$��Center=�5&      $��0,0,0,20q�5'      �� 5*      $��Nombre Completo��6   
���   �$��14(�6F   $	��5,0q�6T     Wpf.Ui.Controls.TextBox  5+      $	��280��5,      $��35��5-      
����������#4A90E2$��1q�50      $
��10,5q�51      $��14(�52      ��53      �� *Name+ �� Mode$ TwoWay=��� 56      $��Nombre de Usuario��6   
���   �$��14(�6H   $��5,10,5,0q�6V     57      $	��280��58      $��35��59      
����������#4A90E2$��1q�5<      $
��10,5q�5=      $��14(�5>      ��5?      �� *
UserName+$ TwoWay=��� 5B      $��Correo Electrónico��6   
���   �$��14(�6I   $��5,10,5,0q�6W     5C      $	��280��5D      $��35��5E      
����������#4A90E2$��1q�5H      $
��10,5q�5I      $��14(�5J      ��5K      �� *Email+$ TwoWay=��� 5N      $��Contraseña��6   
���   �$��14(�6A   $��5,10,5,0q�6O   !  Wpf.Ui.Controls.PasswordBox  5O      $	��280��5P      $��35��5Q      
����������#4A90E2$��1q�5T      $
��10,5q�5U      $��14(�5V         Password 5W      �� *
Password+$ TwoWay=�  Wpf.Ui.Controls.Button  5Z      $��Registrarse��5\      $	��280��5]      $��40��5^      ���#67BF6A
�������$
��Bold"�5a         CornerRadius$ 10��5b      $��Center=�5c      $��0,20,0,0q�5d      ��5[      �� *RegistroCommand+5d        5f      $��Volver al Login��5h      $	��280��5i      $��40��5j      ���#012604
�������$
��Bold"�5m      $ 10��5n      $��Center=�5o      $��0,20,0,0q�5p      ��5g      �� *VolverCommand+5p      5r      5t      5u      5v      