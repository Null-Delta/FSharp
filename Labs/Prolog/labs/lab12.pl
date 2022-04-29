isEasy(Value,Value).
isEasy(1,_).
isEasy(Value, Iter) :- 
    not(0 is Value mod Iter), 
    NewIter is Iter + 1,
    isEasy(Value, NewIter),!.
isEasy(Value, Iter) :- fail.
isEasy(X) :- isEasy(X,2).

%task11
findMaxEasyDivider(X,Y,Del) :-
    0 is X mod Del,
    isEasy(Del),
    Y is Del,!.
findMaxEasyDivider(X,Y,Del) :-
    NewDel is Del - 1,
    findMaxEasyDivider(X,Y,NewDel).
findMaxEasyDividerDown(X,Y) :- findMaxEasyDivider(X,Y,X).

%task12
multNums(X,Y) :- 
    X < 10, 
    Y is X.
multNums(X,Y) :- 
    V is X div 10,
    multNums(V, Y2),
    N is X mod 10,
    Y is Y2 * N.

nod(A,0,A) :- !.
nod(A,1,1) :- !.
nod(A,B,C) :- NewB is A mod B, nod(B, NewB, C).

findMaxUnEasyDivider(X,Y,Del) :-
    0 is X mod Del,
    not(0 is Del mod 2),
    not(isEasy(Del)),
    Y is Del,!.
findMaxUnEasyDivider(X,Y,Del) :-
    NewDel is Del - 1,
    findMaxUnEasyDivider(X,Y,NewDel).
findMaxUnEasyDivider(X,Y) :- findMaxUnEasyDivider(X,Y,X).

task12(X,Y) :- multNums(X,N1),findMaxUnEasyDivider(X,N2), nod(N1,N2,Y).
