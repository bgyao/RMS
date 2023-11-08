using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.BibleBooks;

public enum BookName
{
    #region Old Testament - 39 Book Titles

    #region Pentateuch - 5 Book Titles (1001-1005)
    Genesis = 1001,
    Exodus,
    Leviticus,
    Numbers,
    Deuteronomy,
    #endregion

    #region History Books - 12 Book Titles (1006-1017)
    Joshua,
    Judges,
    Ruth,
    FirstSamuel,
    SecondSamuel,
    FirstKings,
    SecondKings,
    FirstChronicles,
    SecondChronicles,
    Ezra,
    Nehemiah,
    Esther,
    #endregion

    #region Poetry Books - 5 Book Titles (1018-1022)
    Job,
    Psalms,
    Proverbs,
    Ecclesiastes,
    SongofSolomon,
    #endregion

    #region Major Prophets - 5 Book Titles (1023-1027)
    Isaiah,
    Jeremiah,
    Lamentations,
    Ezekiel,
    Daniel,
    #endregion

    #region Minor Prophets - 12 Book Titles (1028-1039)
    Hosea,
    Joel,
    Amos,
    Obadiah,
    Jonah,
    Micah,
    Nahum,
    Habakkuk,
    Zephaniah,
    Haggai,
    Zechariah,
    Malachi = 1039,
    #endregion

    #endregion

    #region New Testament - 27 Book Titles

    #region Gospels and Acts - 5 Book Titles (2001-2005)
    Matthew = 2001,
    Mark,
    Luke,
    John,
    Acts,
    #endregion

    #region Paul's Epistles - 9 Book Titles (2006-2014)
    Romans,
    FirstCorinthians,
    SecondCorinthians,
    Galatians,
    Ephesians,
    Philippians,
    Colossians,
    FirstThessalonians,
    SecondThessalonians,
    #endregion

    #region Paul's Personal Letters - 4 Book Titles (2015-2018)
    FirstTimothy,
    SecondTimothy,
    Titus,
    Philemon,
    #endregion

    #region General Epistles and Revelation - 9 Book Titles (2019-2027)
    Hebrews,
    James,
    FirstPeter,
    SecondPeter,
    FirstJohn,
    SecondJohn,
    ThirdJohn,
    Jude,
    Revelation = 2027,
    #endregion

    #endregion

    //NOTE: Access this region if UserDetails.Religion == Catholic
    #region Apocrypha - 16 Book Titles (3001-3016)
    FirstEsdras = 3001,
    SecondEsdras,
    Tobit,
    Judith,
    EstherAdditions, //Additions to the Book of Esther
    WisdomOfSolomon,
    WisdomOfJesusPrologue, //Prologue to Wisdom of Jesus Son of Sirach
    WisdomOfJesus, //Wisdom of Jesus Son of Sirach
    Baruch,
    LetterOfJeremiah,
    PrayerOfAzariah,
    Susanna,
    BelAndTheDragon,
    PrayerOfManasseh,
    FirstMaccabees,
    SecondMaccabees = 3016,
    #endregion
}
