# TROUBLESHOOTING: Visual Highlighting Not Working

## What Should Happen

When you press Up/Down arrows in the ComboBox:
1. Debug output shows: "? Highlighted item at index X"
2. Debug output shows: "IsKeyboardHighlighted: True"
3. **Blue highlight bar appears on the item**

## If Highlighting Still Doesn't Show

### Step 1: Check Debug Output

Run your app and press Down arrow. You should see:
```
? Highlighted item at index 0: [YourItem]
  IsKeyboardHighlighted: True, Background: ...
```

**If you DON'T see this:**
- The behavior isn't attached correctly
- Check XAML: `behaviors:ComboBoxKeyboardBehavior.EnableKeyboardNavigation="True"`

### Step 2: Verify Template is Applied

Add this temporary code to `EnsureItemContainerStyle` method (after line 78):
```csharp
System.Diagnostics.Debug.WriteLine($"ItemContainerStyle applied to ComboBox");
```

**What to check:**
- You should see "ItemContainerStyle applied to ComboBox" when the window loads
- If NOT ? The behavior's `OnEnableKeyboardNavigationChanged` isn't firing

### Step 3: Check for Existing Styles

**PROBLEM:** If your ComboBox already has an ItemContainerStyle defined in XAML, it might be overriding our template.

**SOLUTION:** Remove any existing ItemContainerStyle from the ComboBox in UserWindow.xaml:

```xaml
<!-- REMOVE OR COMMENT THIS IF IT EXISTS -->
<ComboBox.ItemContainerStyle>
    <Style .../>
</ComboBox.ItemContainerStyle>
```

### Step 4: Test with a Simple ComboBox

Create a test window with minimal code:

```xaml
<Window xmlns:behaviors="clr-namespace:AATM.App.HisWpf.Behaviors">
    <ComboBox x:Name="testCombo"
              IsEditable="True"
              behaviors:ComboBoxKeyboardBehavior.EnableKeyboardNavigation="True">
        <ComboBoxItem Content="Item 1"/>
        <ComboBoxItem Content="Item 2"/>
        <ComboBoxItem Content="Item 3"/>
    </ComboBox>
</Window>
```

**Test:**
1. Click in the ComboBox
2. Press Down arrow
3. Does Item 1 get a blue highlight?

**If YES** ? Problem is with your data-bound ComboBox
**If NO** ? Problem is with the template itself

### Step 5: Check WPF Theme/Styling

Some WPF themes override default colors. Try forcing specific colors:

In `EnsureItemContainerStyle`, change:
```csharp
// BEFORE
keyboardTrigger.Setters.Add(new Setter(Border.BackgroundProperty, SystemColors.HighlightBrush, "Bd"));

// AFTER (use explicit color for testing)
keyboardTrigger.Setters.Add(new Setter(Border.BackgroundProperty, Brushes.Red, "Bd"));
```

If you see **RED** highlight ? SystemColors isn't working, use explicit colors
If you see **NOTHING** ? Template isn't being applied

### Step 6: Nuclear Option - Force Template Refresh

Add this to the end of `ComboBox_DropDownOpened`:

```csharp
// Force visual refresh
comboBox.Items.Refresh();
comboBox.UpdateLayout();
```

### Common Causes & Fixes

| Problem | Cause | Fix |
|---------|-------|-----|
| No debug output | Behavior not attached | Check XAML namespace and property |
| Debug shows "True" but no visual | Template not applied | Check Step 3 (remove existing styles) |
| Works for static items, not data-bound | Container generation timing | Already handled by retry logic |
| Highlight appears then disappears | ClearHighlight called too early | Check for competing event handlers |
| Wrong item highlighted | CollectionView vs Items mismatch | Verify filtering logic |

### Advanced Debugging

Add this to `ApplyHighlight` to inspect the visual tree:

```csharp
// After setting IsKeyboardHighlighted
var template = container.Template;
System.Diagnostics.Debug.WriteLine($"  Template: {template}");
System.Diagnostics.Debug.WriteLine($"  Template.TargetType: {template?.TargetType}");

// Try to find the Border in the template
container.ApplyTemplate();
var border = container.Template?.FindName("Bd", container) as Border;
if (border != null)
{
    System.Diagnostics.Debug.WriteLine($"  Border found! Background: {border.Background}");
}
else
{
    System.Diagnostics.Debug.WriteLine($"  ERROR: Border 'Bd' not found in template!");
}
```

### If STILL Not Working

The issue might be that WPF's FrameworkElementFactory doesn't support triggers properly in all scenarios. 
Use the XAML-based style instead:

1. Open `UserWindow.xaml`
2. Add to Window.Resources:

```xaml
<Window.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="Resources/ComboBoxKeyboardNavigationStyle.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Window.Resources>
```

3. Apply to your ComboBox:

```xaml
<ComboBox ItemContainerStyle="{StaticResource KeyboardNavigableComboBoxItemStyle}"
          behaviors:ComboBoxKeyboardBehavior.EnableKeyboardNavigation="True"
          .../>
```

4. **IMPORTANT:** Modify the behavior code to NOT override the style:

In `OnEnableKeyboardNavigationChanged`, comment out:
```csharp
// Comment this out if using XAML style
// EnsureItemContainerStyle(comboBox);
```

### Expected Debug Output (Working)

```
ItemContainerStyle applied to ComboBox
Moving selection from -1 to 0
? Highlighted item at index 0: EmployeeInfo { Code=001, Name=John }
  IsKeyboardHighlighted: True, Background: System.Windows.Media.SolidColorBrush
[User presses Down arrow]
? Cleared highlight from index 0
? Highlighted item at index 1: EmployeeInfo { Code=002, Name=Jane }
  IsKeyboardHighlighted: True, Background: System.Windows.Media.SolidColorBrush
```

### Visual Indicators to Confirm It's Working

? Item has blue background (or red if you used the test color)
? Item has white text (or contrasting color)
? Highlight moves when you press arrow keys
? Only ONE item is highlighted at a time
? Highlight clears when dropdown closes
? TextBox still has focus (you can type)

### Still Stuck?

Check these files match the solution:
- [ ] `ComboBoxKeyboardBehavior.cs` - Latest version with ControlTemplate
- [ ] `UserWindow.xaml` - ComboBox has EnableKeyboardNavigation="True"
- [ ] `UserWindow.xaml` - ComboBox does NOT have conflicting ItemContainerStyle
- [ ] Debug Output window is visible and filtering for "Highlighted"

### Last Resort: Use Focus-Based Highlighting (Not Recommended)

If template approach completely fails, you can fall back to focus-based highlighting, but you'll need to restore focus to TextBox immediately:

```csharp
private static void ApplyHighlight(ComboBox comboBox, ComboBoxItem container, int index)
{
    comboBox.SetValue(HighlightedIndexProperty, index);
    
    // Store current focus
    var textBox = FindVisualChild<TextBox>(comboBox);
    
    // Temporarily focus the item
    container.Focus();
    
    // Immediately restore focus to TextBox
    textBox?.Dispatcher.BeginInvoke(new Action(() =>
    {
        textBox.Focus();
    }), System.Windows.Threading.DispatcherPriority.Input);
    
    container.BringIntoView();
}
```

This is NOT ideal because:
- ? Causes flicker
- ? May interfere with filtering
- ? May trigger unwanted events
- ? But it WILL show highlighting

Use only as absolute last resort!
