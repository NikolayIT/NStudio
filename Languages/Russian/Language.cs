using System;
using NStudioInterface;

namespace Russian
{
    public class Language : LanguageBase
    {
        public Language()
        {
            // Main Menu
            MenuFile = "Файл";
            MenuEdit = "Правка";
            MenuView = "Вид";
            MenuTools = "Инструменты";
            MenuPlugins = "Расширения";
            MenuHelp = "Помощь";
            // Menu File
            MenuNew = "Создать";
            MenuNewICSharpCode = "ICSharpCode Редактор";
            MenuRichTextEditor = "Rich Text Редактор";
            MenuScinitllaEditor = "Scinitlla Редактор";
            MenuStandardEditor = "Стандартен Редактор";
            MenuHTMLEditor = "HTML Редактор";
            MenuOpen = "Открыть";
            MenuClose = "Закрыть";
            MenuCloseAllDocuments = "Закрыть Все Документы";
            MenuCloseAllDocumentsButThis = "Закрыть Все Документы Кроме Текущего";
            MenuSave = "Сохранить";
            MenuSaveAll = "Сохранить Всё";
            MenuPrint = "Печать";
            MenuPrintPreview = "Параметры печати";
            MenuExit = "Выйти";
            // Menu Edit
            MenuUndo = "Отменить";
            MenuRedo = "Повторить";
            MenuCut = "Вырезать";
            MenuCopy = "Копировать";
            MenuPaste = "Вставить";
            MenuDelete = "Удалить";
            MenuSelectAll = "Выделить Всё";
            MenuTextCase = "Регистр Текста";
            MenuUpperCase = "ЗАГЛАВНЫЙ";
            MenuLowerCase = "прописной";
            MenuCapitalize = "С заглавной буквы";
            MenuInvertCase = "Изменить регистр";
            MenuReversText = "Задом-наперёд";
            // Menu View
            Toolbars = "Панели Инстpументов";
            MenuShowStatusBar = "Показывать Полоса Состояния";
            MenuVisualStyle = "Визуальный Стиль";
            MenuRenderer = "Стиль Меню";
            MenuProgramOpacity = "Прозрачность Программы";
            MenuTopMost = "Всегда Наверху";
            MenuGUILanguage = "Язык интерфейса";
            // Menu Tools
            Options = "Параметры";
            WebBrowser = "Вэб Браузер";
            MenuMathTools = "Математические Инструменты";
            MenuClipboardRing = "Буфеp";
            // Menu Plugins
            MenuLoadPlugin = "Загрузить Расширение...";
            MenuScanPluginFolder = "Сканировать Папку Расширений";
            MenuLoadedPlugins = "Загруженные Расширения";
            // Menu Help
            MenuChangelog = "Журнал Изменений";
            MenuReadme = "Читай Меня!";
            MenuProgramSite = "Страница Программы";
            MenuProgramForum = "Форум Программы";
            MenuAuthorSite = "Сайт Автора";
            MenuAuthorMail = "Почта Автора";
            MenuAboutProgram = "О NStudio";
            // ToolBars
            ToolBarFile = "Файл";
            ToolBarEdit = "Правка";
            ToolBarView = "Вид";
            ToolBarOthers = "Другое";
        }
    }
}
