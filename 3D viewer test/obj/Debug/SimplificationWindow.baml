   M S B A M L   `   `   `  ����I  E3D viewer test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:_3D_viewer
_3D_viewer  5   	   %    _3D_viewer.SimplificationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:_3D_viewer     5   	     � Title$  Mesh Reducer��5   	   $��263.45��6   $��187.135��6.    � WindowStyle$ 
ToolWindow=�6>   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ OpenFilebtn��5      $��	Open File��6&   $��1��6:   $��1��6G   $	��120��6W   $��	10,10,0,0q�6c   $��20��6v   6�   �� 5   
   -   5         ��Name$ Countbox��5      $��1��6&   $
��Left=�66   $��
10,10,0,10q�6Q   $��2��6e   $
��Wrap=�6r   $��Triangle Count:��6�   $	��Top=�6�   �� 5   
   -   5        $ TriangleLabel��5      $��Output Triangle: ��6+   $��3��6D   $��1��6Q   $��	10,10,0,0q�6a   �� 5   
   -   5        $ 
Reducerbtn��5      $��Mesh Reduce��6%   $��1��6;   $
��auto��6K   $��5��6Y   $	��120��6f   $��	10,10,0,0q�6�   �� 5   
   -   5         ��Name$ TrianglesumBox��5      $��1��6*   $
��Left=�6:   $��23��6U   $��	10,10,0,0q�6a   $��4��6t    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   5      5       