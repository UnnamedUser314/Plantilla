   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5      "    LoginRegister.View.LoginView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      6
viewmodels%clr-namespace:LoginRegister.ViewModel  5      $
��auto��5      $
��auto��6   ��5      �� 5   
     �� ImageSource$  /Resources/GreenBG.png��6    j� Stretch$ UniformToFill=�6:   .��5      � $��Center=�6   $��Center=�6&   .+�5   
   ��  �� Padding$ 30q�5       �� CornerRadius$ 15��5      ���#1E1E1E���#444$��2q�5      $	��350��5      $��Center=�5      ._�5      �� $��Center=�6   $��Center=�64   .+�5       �� $��Iniciar Sesión��5!      $��26(�5"      $
��Bold"�5#      
�������$��Center=�5%      $��0,0,0,20q�5&        Wpf.Ui.Controls.TextBox  5)         PlaceholderText$ Usuario��5*      $	��280��5+      $��35��5,      $��0,5,0,10q�5-      
�������
���   ���50      �� *Name+ �� Mode$ TwoWay=�!  Wpf.Ui.Controls.PasswordBox  53      $ Contraseña��54      $	��280��55      $��35��56      $��0,5,0,10q�57      
�������   Password 59      �� *PasswordView+$ TwoWay=�  Wpf.Ui.Controls.Button  5<      $��Iniciar Sesión��5>      $	��280��5?      $��40��5@      ���#4A90E2
�������$
��Bold"�5C         CornerRadius$ 10��5D      $��Center=�5E      $��0,10,0,0q�5F      ��5=      �� *LoginCommand+5F      �� 5I       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��10q�6S   .+�5J      �� $��¿No tienes una cuenta? ��5K      
�������5L      �� 5N      ���#4A90E2	 � Cursor$
	 Hand��65   �� 5O      
 �� Command
 6$   �� *RegisterCommand+.�6H   .�5P      �� $�Regístrate aquí��6"   5Q      5R      5S      5U      5V      5X      5Y      