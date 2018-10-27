# Monaco.NET Api

## General Purpose API Methods

### Monaco.SetTheme
This Function Changes the Current theme of the Monaco Editor.
As of now it can change the theme to:
- Dark
- Light

This function will also soon corespond with a NewTheme function.
```CSharp
public void SetTheme(MonacoTheme theme);
```

### Monaco.SetText
This Method Set's the Text of Monaco's Editor to the given parameter *text*
```CSharp
public void SetText(string text) {
```

### Monaco.GetText
This Method returns the Text of Monaco's Editor.
```CSharp
public string GetText()
```

### Monaco.AppendText
This Method Adds Text to the Monaco Editor on top of it's text already being used.
```CSharp
public void AppendText(string text)
```

## Misc API Methods

### Monaco.GoToLine
This Method Set's the Editor's Scroll Position to the lineNumber, thus going to the line.
(Useful for Errors & Debugging)
```CSharp
public void GoToLine(int lineNumber)
```

### Monaco.EditorRefresh
This Method Refreshes Monaco's Editor.
```CSharp
public void EditorRefresh()
```

### Monaco.UpdateSettings
This Method changes the settings of the Editor using the given parameter *settings*
```CSharp
public void UpdateSettings(MonacoSettings settings)
```
