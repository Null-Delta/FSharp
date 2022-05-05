:- ['library','lab14'].

%task1
lab15task1 :-
    FileName = 'lab15task1output.txt',
    findall(List, generateLab15Task1List(List), Result),
    (exists_file(FileName),delete_file(FileName); told ),
    tell(FileName),
    writeAllWords(Result),
    told,!.
    
generateLab15Task1List(List) :-
    Chars = [97,98,99,100,101,102],
    equalLists(List,[_,_,_,_,_,_,_]),
    all_chars_contrains(Chars,List),
    equal_chars_count(List,4),
    inList(Chars,A),
    inList(Chars,B),
    not(A is B),
    char_count_in_list(List,A,2),
    char_count_in_list(List,B,3).