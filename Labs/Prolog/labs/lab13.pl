printArrayWithStep2([], Index).
printArrayWithStep2([H|T], Index) :-
    0 is Index mod 2,
    NewIndex is Index + 1,
    write(H),write(', '),
    printArrayWithStep2(T, NewIndex),!.
printArrayWithStep2([H|T], Index) :-
    NewIndex is Index + 1,
    printArrayWithStep2(T, NewIndex),!.

printArrayParts(List) :-
    printArrayWithStep2(List,1),
    nl,
    printArrayWithStep2(List,0).
    
