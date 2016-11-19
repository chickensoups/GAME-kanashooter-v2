using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class LevelUtils 
{
	private static List<Level> levels; //hold all levels data
    public static Level currentLevel;

	public static void initLevel()
	{
		//Common Datas
		int index;
		string name;
		List<string> answer;
		List<string> question;
		string welcomeMessage;
		int enemyEachWaveCount = 5; 
		float waveWait = 4;
		float spawnWait = 4;
		bool isRotate;
		bool isFaster;

		//HIRAGANA Zone
		//level 1
		index = 1;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"a", "i", "u", "e", "o"
		});
		question = new List<string> (new[] {
			"あ", "い", "う", "え", "お"
		});
		welcomeMessage = "Welcome to Hiragana Zone!";
		isRotate = false;
		isFaster = false;
		Level level1=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 2
		index = 2;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ka", "ki", "ku", "ke", "ko"
		});
		question = new List<string> (new[] {
			"か", "き", "く", "け", "こ"
		});
		welcomeMessage = "Ops, nice bro! try this one!";
		isRotate = false;
		isFaster = true;
		Level level2=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 3
		index = 3;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"sa", "shi", "su", "se", "so"
		});
		question = new List<string> (new[] {
			"さ", "し", "す", "せ", "そ"
		});
		welcomeMessage = "Rolling in the deep!";
		isRotate = true;
		isFaster = false;
		Level level3=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 4
		index = 4;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ta", "chi", "tsu", "te", "to"
		});
		question = new List<string> (new[] {
			"た", "ち", "つ", "て", "と"
		});
		welcomeMessage = "Time to learn something new =.=";
		isRotate = false;
		isFaster = false;
		Level level4=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 5
		index = 5;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"na", "ni", "nu", "ne", "no"
		});
		question = new List<string> (new[] {
			"な", "に", "ぬ", "ね", "の"
		});
		welcomeMessage = "Na` na` na na' na na' na (The Beatles - Hey Jude)";
		isRotate = false;
		isFaster = true;
		Level level5=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 6
		index = 6;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ha", "hi", "fu", "he", "ho"
		});
		question = new List<string> (new[] {
			"は", "ひ", "ふ", "へ", "ほ"
		});
		welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
		isRotate = true;
		isFaster = true;
		Level level6=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 7
		index = 7;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ma", "mi", "mu", "me", "mo"
		});
		question = new List<string> (new[] {
			"ま", "み", "む", "め", "も"
		});
		welcomeMessage = "Finding MeMo @@";
		isRotate = true;
		isFaster = false;
		Level level7=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 8
		index = 8;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ra", "ri", "ru", "re", "ro"
		});
		question = new List<string> (new[] {
			"ら", "り", "る", "れ", "ろ"
		});
		welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
		isRotate = true;
		isFaster = false;
		Level level8=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 9
		index = 9;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ya", "yu", "yo"
		});
		question = new List<string> (new[] {
			"や", "ゆ", "よ"
		});
		welcomeMessage = "Only 3 enemy types, are you happy!";
		isRotate = true;
		isFaster = true;
		Level level9=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 10
		index = 10;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"wa", "wo", "n"
		});
		question = new List<string> (new[] {
			"わ", "を", "ん"
		});
		welcomeMessage = "3 enemy types again! Not so happy this time!";
		isRotate = true;
		isFaster = true;
		Level level10=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//TAKAGANA ZONE
		//level 11
		index = 11;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"a", "i", "u", "e", "o"
		});
		question = new List<string> (new[] {
			"ア", "イ", "ウ", "エ", "オ"
		});
		welcomeMessage = "Welcome to Takagana Zone!";
		isRotate = false;
		isFaster = false;
		Level level11=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 12
		index = 12;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ka", "ki", "ku", "ke", "ko"
		});
		question = new List<string> (new[] {
			"カ", "キ", "ク", "ケ", "コ"
		});
		welcomeMessage = "Ops, nice bro! try this one!";
		isRotate = false;
		isFaster = true;
		Level level12=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 13
		index = 13;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"sa", "shi", "su", "se", "so"
		});
		question = new List<string> (new[] {
			"サ", "シ", "ス", "セ", "ソ"
		});
		welcomeMessage = "Rolling in the deep!";
		isRotate = true;
		isFaster = false;
		Level level13=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 14
		index = 14;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ta", "chi", "tsu", "te", "to"
		});
		question = new List<string> (new[] {
			"タ", "チ", "ツ", "テ", "ト"
		});
		welcomeMessage = "Time to learn something new =.=";
		isRotate = false;
		isFaster = false;
		Level level14=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 15
		index = 15;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"na", "ni", "nu", "ne", "no"
		});
		question = new List<string> (new[] {
			"ナ", "ニ", "ヌ", "ネ", "ノ"
		});
		welcomeMessage = "Na` na` na na' na na' na (The Beatles - Hey Jude)";
		isRotate = false;
		isFaster = true;
		Level level15=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 16
		index = 16;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ha", "hi", "fu", "he", "ho"
		});
		question = new List<string> (new[] {
			"ハ", "ヒ", "フ", "ヘ", "ホ"
		});
		welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
		isRotate = true;
		isFaster = true;
		Level level16=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 17
		index = 17;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ma", "mi", "mu", "me", "mo"
		});
		question = new List<string> (new[] {
			"マ", "ミ", "ム", "メ", "モ"
		});
		welcomeMessage = "Finding MeMo @@";
		isRotate = true;
		isFaster = false;
		Level level17=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 18
		index = 18;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ra", "ri", "ru", "re", "ro"
		});
		question = new List<string> (new[] {
			"ラ", "リ", "ル", "レ", "ロ"
		});
		welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
		isRotate = true;
		isFaster = false;
		Level level18=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 19
		index = 19;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"ya", "yu", "yo"
		});
		question = new List<string> (new[] {
			"ヤ", "ユ", "ヨ"
		});
		welcomeMessage = "Only 3 enemy types, are you happy!";
		isRotate = true;
		isFaster = true;
		Level level19=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//level 20
		index = 20;
		name = "Level " + index;
		answer = new List<string> (new[] {
			"wa", "wo", "n"
		});
		question = new List<string> (new[] {
			"ワ", "ヲ", "ン"
		});
		welcomeMessage = "3 enemy types again! Not so happy this time!";
		isRotate = true;
		isFaster = true;
		Level level20=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//Level All HIRAGANA
		//Level 21
		index = 21;
		name = "Level " + index;
		answer = new List<string> (new[] {"a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n"});
		question = new List<string> (new[] {"あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん"});
		welcomeMessage = "Try to beat last round of HIRAGANA!";
		isRotate = true;
		isFaster = true;
		Level level21=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//Level All KATAGANA
		//Level 22
		index = 22;
		name = "Level " + index;
		answer = new List<string> (new[] {"a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n"});
		question = new List<string> (new[] {"ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン"});
		welcomeMessage = "Try to beat last round of KATAKANA!";
		isRotate = true;
		isFaster = true;
		Level level22=new Level(index, name, welcomeMessage, question, answer, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

		//push all level into levels
		levels =
			new List<Level>(new Level[]
				{
					level1, level2, level3, level4, level5, level6, level7, level8, level9, level10,
					level11, level12, level13, level14, level15, level16, level17, level18, level19, level20,
					level21, level22
				});

	}//END INIT()

    public static Level GetLevel(int index)
    {
        if (index <= 0)
        {
            return levels.First();
        }
        if (index >= levels.Count - 1)
        {
            return levels.Last();
        }
        return levels[index];
    }
}
