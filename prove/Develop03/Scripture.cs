public class Scripture{
    
    private Reference _reference = new Reference();
    private _words = new List<Word>;

    public Scripture(Reference reference, string text){
        this._reference = reference
        string[] words = text.Split(" ");
        foreach(string w in words){
            Word word = new Word(w);
            _words.Add(word);
        }
        
    }
    public void HideWords(int numToHide){

    }

    public string GetDisplayText(){

    }

    public bool IsCompletelyHidden(){

    }
}