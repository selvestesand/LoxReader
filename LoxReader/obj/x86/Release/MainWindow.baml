   M S B A M L   `   `   `  ���� D  @LoxReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LoxReader	LoxReader      LoxReader.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:LoxReader     -     �Name$  	AppWindow�� � WindowStyle$
 None=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=� � Icon$ Images/Decrypted.png�� � Title$ 	Loxreader������ *WindowMinimumWidth+ �� FallbackValue$	 400������ *WindowMinimumHeight+$	 400������ *WindowHeight+���� *WindowWidth+ � 	Resources    LoxReader.MainWindow �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� Padding ��Name   MelinVeryLightBrush �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions K� ZIndex � ColumnDefinitions  SystemIconButton  
HeaderText  LatoBold  FontSizeRegular  MelinDarkGreyBrush  MelinDarkPurpleBrush �� Orientation  WindowControlButton  WindowCloseButton o� 
IsMainMenu 	 FontSizeSmall 
 LatoRegular m� IsCheckable �� 
StartPoint �� EndPoint  MelinLightGrey � Color � Offset  MelinDarkGrey  MelinVeryLight��%�  '        7   7   7   7  7  7  7  7  7  7  7  7  7  7  7   7 	 7 
 7  7  7  7  7  �� "  .��� 	 � ��
 �� " �.R���  �� *OuterMarginSizeThickness+$ 10��._�� .+��� $ 	Container��8��   �� *WindowCornerRadius+$ 2���� 8��  �� *WindowCornerRadius+$ 2��   $ 6Q�$
 0.15Q��  !�  �� $ 	Container�� �� ���� *TitleHeightGridLength+$ 42���� $
��Auto ��� $��* �.+�� $��0��$ 1��8��  �� $
��Auto ��� $��* ��� $
��Auto �.+��� 8�� ���� *MenuCommand+.���� $��/Images/Decrypted.png��(� $��3��.���� 8�� �� 8�� 8�� 8�� .�Lox�� 8�� 8��	 8��
 .�Reader�� $��2��$ 
Horizontal=�.+��� 8�� $��_������ *MinimizeCommand+�� 8�� $	��[ ]������ *MaximizeCommand+�� 8�� $��X������ *CloseCommand+� $��1��8�� .+�o�  . 8�� 8�� $
��Auto��$
��Auto��
������ .@�m� $
��File��.@�m� $	��New��$��New...��m� $
��Open��$��Open...���� m� $
��Save��$
��Save��m� $��SaveAs��$��
Save As...���� m� $��Close��$��Close��m� $
��Edit��.@�m� $
��Undo��$
��Undo��m� $
��Redo��$
��Redo���� m� $
��Find��$
��Find��m� $��FindAndReplace��$��Find and Replace��m� $��Tools��.@�m� $��EncryptString��$��Encrypt String��m� $��DecryptString��$��Decrypt String��m� $��Status��.@�m� $��
ShowStatus��$��Show Status�� . m� $��About���� $��2��$��6��$��	0 0.2 0 0q����� $	 0,0&�$	 1,0&�.��� 8  $	 0.0Q�� 8  $	 0.5Q�� 8  $	 1.0Q����� $	 0,0&�$	 0,1&�.��� 8  $	 0.0Q�� 8  $	 1.0Q��� $��2�� �� *InnerContentPaddingThickness+._��� #��z��'  !System.Windows.Shell.WindowChrome   WindowChrome       GlassFrameThickness$  0q�!   CornerRadius$! 0��"   ResizeBorderThickness" �� *ResizeBorderThickness+#   CaptionHeight# �� *TitleHeight+.���  �� $	��250 ��� $��* �.+� � -   $  �Name$$ LeftContentFrame��$��0������ *LeftSidePage+% �� 	Converter% -  'LoxReader.ApplicationPageValueConverter   � -   $$ MainContentFrame��$��1������ *RightSidePage+%   