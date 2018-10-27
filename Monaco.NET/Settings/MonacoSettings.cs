using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonacoNET.Settings {
    public struct MonacoSettings {
        public bool   ReadOnly;                 // Disables/Enables The Ability to Edit The Text.
        public bool   AutoIndent;               // Enables auto Indentation & Adjustment
        public bool   DragAndDrop;              // Enables Drag & Drop For Moving Selections of Text.
        public bool   Folding;                  // Enables Code Folding.
        public bool   FontLigatures;            // Enables Font Ligatures.
        public bool   FormatOnPaste;            // Enables Formatting on Copy & Paste.
        public bool   FormatOnType;             // Enables Formatting On Typing.
        public bool   Links;                    // Enables Whether Links are clickable & detectible.
        public bool   MinimapEnabled;           // Enables Whether Code Minimap is Enabled.
        public bool   MatchBrackets;            // Enables Highlighting of Matching Brackets.
        public int    LetterSpacing;            // Set's the Letter Spacing Between Characters.
        public int    LineHeight;               // Set's the Line Height.
        public int    FontSize;                 // Determine's the Font Size of the Text.
        public string FontFamily;               // Set's The Font Family for the Editor.
        public string RenderWhitespace;         // "none" | "boundary" | "all"
    };
}
