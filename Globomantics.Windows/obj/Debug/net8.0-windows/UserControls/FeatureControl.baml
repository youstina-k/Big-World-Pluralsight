   M S B A M L   `   `   `  ����O  KGlobomantics.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Globomantics.Windows.UserControls!Globomantics.Windows.UserControls  5      6    0Globomantics.Windows.UserControls.FeatureControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Globomantics.Windows.UserControls     5        � 	Resources  5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      �� .��5   
   �� $��10q�6   .+�5      �� $
��Bold"�6   .��6&   	Feature6/   �� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Title6?   �� 5      ��6   �� *Title+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Description6E   �� 5      ��6   �� *Description+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   
Due date6B   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *	DueDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��0,10,0,0q�6   $
��Bold"�6&   .��68   Attach to parent6J   �� 5      -   5         ��Name$ 
ParentTodo��5       �� Text$ Do not attach��5      $|�False��5       �� 
IsEditable$
 True��5       �� 
IsReadOnly$
 True��5       �� DisplayMemberPath$ Title��5      ��5   +   �� *AvailableParentTasks+	 �� SelectedItem	 5   ,   �� *Parent+5      �� 5!      $��0,10,0,0q�6   $��Center=�6K   $��Center=�6f   
 d� 	IsChecked
 6)   �� *IsCompleted+.��5"      �� $��	Completed��6   $
��Bold"�6-   $��Center=�6?   5#      �� 5%      $��0,10,0,0q�6   $��Delete��6�   y�6'   �� *
IsExisting+ �� 	Converter# [  ��6�   �� *DeleteCommand+6�   �� 5&      $��0,10,0,0q�6   $
��Save��6G   ��6'   �� *SaveCommand+6G   5'      5(      5)      