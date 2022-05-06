:- ['library','lab14','generatorLib'].

%task1
lab15task1 :- writeResultInFile(generateLab15Task1List(_), 'lab15task1output.txt').
    
generateLab15Task1List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_,_,_,_],
    Chars --/ A /-- CWA,
    CWA --/ B /-- CWAB,
    CWAB /?- 2 --/ [C,D],
    List <-- A -? 3,
    List <-- B -? 2,
    List <-- [C,D] -? 1,
    writeString(List),nl.

%task2
lab15task2 :- writeResultInFile(generateLab15Task2List(_), 'lab15task2output.txt').

generateLab15Task2List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_,_,_,_,_,_],
    Chars /?- 2 --/ [A,B] /-- CWAB,
    CWAB --/ C /-- CWABC,
    CWABC /?- 2 --/ [D,E],
    List <-- C -? 3,
    List <-- [A,B] -? 2,
    List <-- [D,E] -? 1,
    writeString(List),nl.

%task3
lab15task3 :- writeResultInFile(generateLab15Task3List(_), 'lab15task3output.txt').

generateLab15Task3List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_],
    Chars --/ 97 /-- CWA,
    CWA --/ B,
    List <-- 97 -? 3, List <-- B,
    writeString(List),nl.

generateLab15Task3List(List) :-
    List ~ [_,_,_,_],
    List <-- 97 -? 4,
    writeString(List),nl.

%task4
lab15task4 :- writeResultInFile(generateLab15Task4List(_), 'lab15task4output.txt').

generateLab15Task4List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_,_,_,_],
    Chars --/ A /-- CWA,
    CWA /?- 3 --/ [B,C,D],
    List <-- [B,C,D] -? 1,
    List <-- A -? 4,
    writeString(List),nl.

generateLab15Task4List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_,_,_,_],
    Chars --/ A /-- CWA,
    CWA --/ B /-- CWAB,
    CWAB /?- 2 --/ [C,D],
    List <-- A -? 3,
    List <-- B -? 2,
    List <-- [C,D] -? 1,
    writeString(List),nl.

generateLab15Task4List(List) :-
    Chars = [97,98,99,100,101,102],
    List ~ [_,_,_,_,_,_,_],
    Chars --/ A /-- CWA,
    CWA /?- 3 --/ [B,C,D],
    List <-- A,
    List <-- [B,C,D] -? 2,
    writeString(List),nl.
