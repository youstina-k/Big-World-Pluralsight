   M S B A M L   `   `   `  ����O  KGlobomantics.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Globomantics.Windows.ConvertersGlobomantics.Windows.Converters  5   K   2    ,Globomantics.Windows.UserControls.BugControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      D
converters-clr-namespace:Globomantics.Windows.Converters     6K     � 	Resources  5          BooleanToVisibilityConverter:   4Globomantics.Windows.Converters.ByteToImageConverter  ByteToImageConverter��%:   &	        &	      �� 5	   
   6'     5
   
   6*   5      .��5      �� .��5   
   �� $��10q�6   .+�5      �� $
��Bold"�6   .��6&   Bug6+   �� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Title6?   �� 5      ��6   �� *Title+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Description6E   �� 5      ��6   �� *Description+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Affected version6J   �� 5      ��6   �� *AffectedVersion+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   Affected users6H   �� 5      ��6   �� *AffectedUsers+�� 5      $
��Bold"�6   $��0,10,0,0q�6&   .��68   
Due date6B   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *	DueDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��0,10,0,0q�6   $
��Bold"�6&   .��68   
Severity6B   �� 5        �� Text$ Do not attach��5!      $|�False��5"       �� 
IsEditable$
 True��5#       �� 
IsReadOnly$
 True��5$      ��5       �� *SeverityLevels+ �� SelectedValue 5!   ,   �� *
Severity+5$      �� 5&      $��0,10,0,0q�6   $
��Bold"�6&   .��68   Attach to parent6J   �� 5'      -   5         ��Name$ 
ParentTodo��5'      $ Do not attach��5(      $|�False��5)      $
 True��5*      $
 True��5+      	 �� DisplayMemberPath$	 Title��5,      ��5'   +   �� *AvailableParentTasks+
 �� SelectedItem
 5(   ,   �� *Parent+5,      �� 5.      $��0,10,0,0q�6   $��Center=�6K   $��Center=�6f    d� 	IsChecked 6)   �� *IsCompleted+.��5/      �� $��	Completed��6   $
��Bold"�6-   $��Center=�6?   50      �� 52      $��0,10,0,0q�6   $��Delete��6�   y�6'   �� *
IsExisting+ �� 	Converter# [  ��6�   �� *DeleteCommand+6�   �� 53      $��0,10,0,0q�6   $
��Save��6G   ��6'   �� *SaveCommand+6G   54      55      56      