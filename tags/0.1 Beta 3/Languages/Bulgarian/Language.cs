using System;
using NStudioInterface;

namespace Bulgarian
{
    public class Language : LanguageBase
    {
        public Language()
        {
            // Main Menu
            MenuFile = "Файл";
            MenuEdit = "Редактиране";
            MenuView = "Изглед";
            MenuTools = "Инструменти";
            MenuPlugins = "Добавки";
            MenuHelp = "Помощ";
            // Menu File
            MenuNew = "Нов";
            MenuNewICSharpCode = "ICSharpCode Редактор";
            MenuRichTextEditor = "Rich Text Редактор";
            MenuScinitllaEditor = "Scinitlla Редактор";
            MenuStandardEditor = "Стандартен Редактор";
            MenuHTMLEditor = "HTML Редактор";
            MenuOpen = "Отвори";
            MenuClose = "Затвори";
            MenuCloseAllDocuments = "Затвори Всички Документи";
            MenuCloseAllDocumentsButThis = "Затвори Всички Документи Без Този";
            MenuSave = "Запази";
            MenuSaveAll = "Запази Всички";
            MenuPrint = "Печат";
            MenuPrintPreview = "Печат Преглед";
            MenuExit = "Изход";
            // Menu Edit
            MenuUndo = "Отмени";
            MenuRedo = "Върни";
            MenuCut = "Изрежи";
            MenuCopy = "Копирай";
            MenuPaste = "Постави";
            MenuDelete = "Изтрий";
            MenuSelectAll = "Избери Всичко";
            MenuTextCase = "Големина на Буквите";
            MenuUpperCase = "Големи Букви";
            MenuLowerCase = "Малки Букви";
            MenuCapitalize = "Думите с Главни Букви";
            MenuInvertCase = "Смяна Големи/Малки Букви";
            MenuReversText = "Обръщане на Текста";
            // Menu View
            Toolbars = "Тулбарове";
            MenuShowStatusBar = "Показвай Лентата със Състоянието";
            MenuVisualStyle = "Визуален Стил";
            MenuRenderer = "Стил на Менюто и Тулбаровете";
            MenuProgramOpacity = "Прозрачност";
            MenuTopMost = "Винаги най-отгоре";
            MenuGUILanguage = "Език";
            // Menu Tools
            Options = "Настройки";
            WebBrowser = "Web Browser";
            MenuMathTools = "Математически Инструменти";
            MenuClipboardRing = "История на Клипборда";
            // Menu Plugins
            MenuLoadPlugin = "Зареди добавка...";
            MenuScanPluginFolder = "Сканирай Плъгин Папката";
            MenuLoadedPlugins = "Заредени Добавки";
            // Menu Help
            MenuChangelog = "Промени";
            MenuReadme = "Прочети!";
            MenuProgramSite = "Сайт на Програмата";
            MenuProgramForum = "Форум на Програмата";
            MenuAuthorSite = "Сайт на Автора";
            MenuAuthorMail = "E-Mail на Автора";
            MenuAboutProgram = "За NStudio...";
            // ToolBars
            ToolBarFile = "Файл";
            ToolBarEdit = "Редактиране";
            ToolBarView = "Изглед";
            ToolBarOthers = "Инструменти";
        }
    }
}
