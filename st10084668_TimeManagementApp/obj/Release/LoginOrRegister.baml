   M S B A M L   `   `   `  ���� W  Sst10084668_TimeManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:st10084668_TimeManagementAppst10084668_TimeManagementApp  2    ,st10084668_TimeManagementApp.LoginOrRegister   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:st10084668_TimeManagementApp     $	��300��$	��600��  � WindowStartupLocation$  CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency . .����  �� CornerRadius$ 10������  �� ImageSource$" \Images\login background.PNG��._�� .+��� $��Register��$
��Left=�$��	81,23,0,0q�$	��Top=�$��Baskerville Old Face)�$��24(�$
��Bold"���Z� �� $��Login��$
��Left=�$��
403,23,0,0q�$	��Top=�$��Baskerville Old Face)�$��24(�$
��Bold"��� $��2��
���   �$��187,170,186,128q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -90.137Q�T� �� $��
Username: ��$
��Left=�$��351,109,0,0q�$	��Top=�$��Baskerville Old Face)�$
��Bold"��� $��	Password:��$
��Left=�$��351,184,0,0q�$	��Top=�$��Baskerville Old Face)�$
��Bold"��� $��
Username: ��$
��Left=�$��
36,109,0,0q�$	��Top=�$��Baskerville Old Face)�$
��Bold"��� $��	Password:��$
��Left=�$��
36,184,0,0q�$	��Top=�$��Baskerville Old Face)�$
��Bold"��� -    ��Name$ tbLuser��$
��Left=�$��	351,0,0,0q�	 �� TextWrapping$
	 Wrap=�$��Center=�$	��132��$��18(�$��Baskerville Old Face)�$��24��
 J� Opacity$	
 0.7Q�.�� � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 8��.������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$
 Gray�� � Offset$ 1Q�� $ 	#FFF4E0E0��$ 0.234Q�.���� -   $ tbLPass��$
��Left=�$��351,217,0,0q�$
	 Wrap=�$	��Top=�$	��132��$��18(�$��Baskerville Old Face)�$��23��$	
 0.7Q�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 8��.������ $ 0.5,1&�$ 0.5,0&�.��� $
 Gray��$ 1Q�� $ 	#FFF4E0E0��$ 0.234Q�.���� -   $ tbRUser��$
��Left=�$��24,0,0,0q�$
	 Wrap=�$��Center=�$	��132��$��18(�$��Baskerville Old Face)�$��23��$	
 0.7Q�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 8��.������ $ 0.5,1&�$ 0.5,0&�.��� $
 Gray��$ 1Q�� $ 	#FFF4E0E0��$ 0.234Q�.���� -   $ tbRPass��$
��Left=�$��
24,213,0,0q�$
	 Wrap=�$	��Top=�$	��132��$��18(�$��Baskerville Old Face)�$��23��$	
 0.7Q�.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 8��.������ $ 0.5,1&�$ 0.5,0&�.��� $
 Gray��$ 1Q�� $ 	#FFF4E0E0��$ 0.234Q�.���� -    ��Name$ btnLogin��$��Login��$
��Left=�$��520,264,0,0q�$	��Top=�$��Baskerville Old Face)�$
��Bold"�$��26��$��70�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF71DF8D��$ 0.234Q�� $ 	#FF17B840��$ 0.826Q��� -   $ btnReg��$��Register��$
��Left=�$��209,264,0,0q�$	��Top=�$��26��$��70��$��Baskerville Old Face)�$
��Bold"� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF17B840��$ 0.819Q�� $ 	#FF71DF8D��$ 0.237Q��� $
��Left=�$��13��$��	488,0,0,0q�$��Center=�$��20��$��/username image.png���� $
��Left=�$��12��$��161,219,0,0q�$	��Top=�$��20��$��/Lock image.png���� $
��Left=�$��12��$��488,225,0,0q�$	��Top=�$��20��$��/Lock image.png���� $
��Left=�$��12��$��	160,0,0,0q�$��Center=�$��20��$��/username image.png���� -   $
��Exit��$
��Left=�$��
554,10,0,0q�$	��Top=�$��Baskerville Old Face)�$��16��$��36�����	#FF5DA0A4���	#FF384A49 ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��