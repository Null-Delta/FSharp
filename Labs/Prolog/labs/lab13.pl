%task39
printArrayWithStep2([], _).
printArrayWithStep2([H|T], Index) :-
    0 is Index mod 2,
    NewIndex is Index + 1,
    write(H),write(', '),
    printArrayWithStep2(T, NewIndex),!.
printArrayWithStep2([_|T], Index) :-
    NewIndex is Index + 1,
    printArrayWithStep2(T, NewIndex),!.

printArrayParts(List) :-
    printArrayWithStep2(List,1),
    nl,
    printArrayWithStep2(List,0).
    
%task45
findSum([],_,_,R,R).
findSum([H|T],A,B,R,LR) :-
    H =< B,
    H >= A,
    NewLR is LR + H,
    findSum(T,A,B,R,NewLR).
findSum([H|T],A,B,R,LR) :- findSum(T,A,B,R,LR).
findSum(List,A,B,R) :- findSum(List,A,B,R,0).