isEasy(Value,Value).
isEasy(Value, Iter) :- 
    not(0 is Value mod Iter), 
    NewIter is Iter + 1,
    isEasy(Value, NewIter),!.
isEasy(Value, Iter) :- fail.
isEasy(X) :- isEasy(X,2).

%task11
findMaxEasyDividerUp(X,Del) :-
    0 is X mod Del,
    isEasy(Del),
    write(Del),nl,!.
findMaxEasyDividerUp(X,Del) :-
    NewDel is Del - 1,
    findMaxEasyDivider(X,NewDel).
findMaxEasyDivider(X) :- findMaxEasyDivider(X,X).