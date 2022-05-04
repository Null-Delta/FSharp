:- ['lab13'].

%чтение строки
readString(String) :- get0(X),inputString(String,[], X).

%обработка ввода
inputString(A,B, 10) :- A = B,!.
inputString(Str,LocalStr, Char) :-
    pushBack(LocalStr, Char, NewLocalStr),
    get0(X),
    inputString(Str, NewLocalStr, X),!.

%вывод строки
writeString([]) :- !.
writeString([H|T]) :- put(H), writeString(T).

%получить первое слово в строке и вернуть остаток строки
getFirstWord([], Word, _, Word).
getFirstWord([H|T], Word, Tail, LWord) :-
    (
        32 is H, Word = LWord, Tail = T;

        pushBack(LWord,H,NewLWord),
        getFirstWord(T,Word,Tail, NewLWord)
    ).
getFirstWord(List, Word, Tail) :- getFirstWord(List, Word, Tail, []).

%получить все слова в строке
getAllWords([], List, List).
getAllWords(String, List, LocalList) :-
    getFirstWord(String, Word, Tail),
    pushBack(LocalList, Word, NewLocalList),
    getAllWords(Tail, List, NewLocalList).
getAllWords(String, List) :- getAllWords(String, List, []).

writeAllWords([]).
writeAllWords([H|T]) :- writeString(H),nl, writeAllWords(T),!.

%task1l
task1_1 :- readString(X), writeString(X),write(','),writeString(X),write(','),writeString(X).
task1_2 :- readString(X), getAllWords(X,List),lenght(List,Y), write(Y),!.
task1_3 :- 
    readString(X),
    getAllWords(X,List),
    generateList1(List, UniqueWords),
    generateList2(List, UniqueWords, CountOfWords),
    findMax(CountOfWords, Max),
    findIndex(CountOfWords, Max, Index),
    getValue(UniqueWords, Index, Value),
    writeString(Value),!.

writeChar(_,0).
writeChar(Char,Count) :- put(Char), NewCount is Count - 1, writeChar(Char, NewCount).

task1_4 :- 
    readString(X),
    lenght(X,L),
    (
        L =< 5,
        equal(X,[H1|_]),
        writeChar(H1,L);

        equal(X,[F1,F2,F3|_]),
        put(F1),put(F2),put(F3),

        reverseList(X, RevX),

        equal(RevX,[L1,L2,L3|_]),
        put(L3),put(L2),put(L1)
    ),!.

printIndex([],_,_).
printIndex([H|T], Value, Index) :-
    NewIndex is Index + 1,
    (
        H is Value,
        write(Index),write(' '),
        printIndex(T,Value,NewIndex);
        printIndex(T,Value,NewIndex)
    ).

task1_5 :- 
    readString(X),
    reverseList(X, RevX),
    equal(RevX, [LastChar|_]),
    printIndex(X,LastChar,0),!.