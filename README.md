<details>
  <summary>Screenshots</summary>
  <p>
    <img src="https://i.imgur.com/cP0Gnx1.png" alt="Image #1">
    <img src="https://i.imgur.com/kD9Zlsw.png" alt="Image #2">
    <img src="https://i.imgur.com/Lor0MA8.png" alt="Image #3">
    <img src="https://i.imgur.com/bfbcdrQ.png" alt="Image #4">
  </p>
</details>

# Frankensteiner
Frankensteiner is a program that allows you to create asymmetrical faces for your Mordhau characters. What would otherwise be a gruesome process of individually changing up to 147 values, can now be done through a user-friendly interface instead.

## Getting Started
If you don't want to build it yourself, you can download the latest version from the [Releases](https://github.com/Dealman/Frankensteiner/releases) page.

### Prerequisites
In order to use this program you need to at least have **.NET Framework 4.5.0** or above.

### Installing
There's no installation required, it's a simple executable which you can put wherever you find appropriate.

## How to Use
When you first run the program it will ask you whether you want to locate the config file manually or automagically. It is recommended you try and let it find it automagically since it's usually located in the local appdata folder. Once your configuration file has been found, the program will automatically load your mercenaries.

### Selection
You can select either one or multiple mercenaries. If you want to select multiple mercenaries, it works like any other list. You can hold CTRL to select individual entries - or hold Shift to select all entries between the first and last selection.

### Editing
If you have only one mercenary selected, you can either double-click or press enter to open the Mercenary Editor. Here, you can change all of the face values as you please and also change the name.

If you have multiple mercenaries selected, you can not use the Mercenary Editor. But you can Randomize and Frankenstein them via the context menu *(right-click)*, or shortcuts.

### Backups
This program has the option to automatically create backups before any changes are made. You also have the option to save old backups by compressing them into a ZIP archive. You can also limit the number of backups this archive should contain, 0 being no limit.

### Shortcuts
Under Settings you can enable shortcuts, this is useful for when you wanna make changes quickly.

| Shortcut | Description | Supports Multi-Selection? |
| -------- | ----------- | ------------------------- |
| Enter/Return | Open Mercenary Editor | No          |
| CTRL+Z | Revert Changes | Yes                      |
| CTRL+S | Save Changes | Yes                        |
| CTRL+E | Export to Clipboard | Yes                 |
| CTRL+R | Randomize | Yes                           |
| CTRL+F | Frankenstein | Yes                        |
| CTRL+A | Select All Mercenaries | Yes              |
| CTRL+C | Copy Face Values | No                     |
| CTRL+V | Paste Face Values | Yes                   |

### Conflicts
It is recommended that you do not have Mordhau running when using this program. Or at the very least, do not idle in the customization menu - since Mordhau will write to the config every single time you make even the tiniest of changes. Or else it's very likely there will be conflicts when trying to save **your** changes.

But in such a case, I have implemented an experimental feature to solve conflicts. If there are conflicts it will ask you to resolve them - a new window will open up showing you the conflicted entries you want to save in the list on the **left**.

And the list on the **right** contain the new mercenaries which may contain changes made by Mordhau. Simply select which one of these you want to replace and it should be able to save them just fine.
