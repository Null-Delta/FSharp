:- ['library', 'combinatorics'].

%-----чтение------

readVertexes(V, Vs) :-
    getAllWords(Vs, Words),
    mapList(
        [Inp, Out]>>(
            string_to_atom(Inp, InpAtom),
            atom_number(InpAtom, Out)
        ),
        Words,
        V
    ),!.

readEdges([],[]).

readEdges(Edges,[H|T]) :-
    getAllWords(H,Words),
    mapList(
        [Inp, Out]>>(
            string_to_atom(Inp, InpAtom),
            atom_number(InpAtom, Out)
        ),
        Words,
        [V1,V2]
    ),
    readEdges(NextEdges,T),
    Edges ~ [(V1,V2) | NextEdges].
    

readGraph((V,E)) :-
    readFile('lab15_graph_input.txt', [Vertexes|Edges]),
    readVertexes(V,Vertexes),
    readEdges(E,Edges),!.

%-----чтение------

:- op(1,xfy, :).
:- op(2,xfy, --).
:- op(2,xfy, ->).
:- op(2,xfy, -?-).

% проверяет существует ли ребро V1-V2 в графе (V,E)
% синтаксис:
% <Граф с вершинами V и ребрами E> : <Первая вершина> -- <вторая вершина>
(V,E) : V1 -- V2 :-
    (contains(E,(V1,V2));contains(E,(V2,V1))),!.

% проверяет существует ли путь от вершины V1 в вершину V2
% синтаксис:
% <Граф с вершинами V и ребрами E> : <Первая вершина> -?- <вторая вершина>
(V,E) : V1 -?- V2 :- 
    (V,E): V1 -- V2,!;
    (V,E): V1 -- X1, (V,E): X2 -- V2, (V,E): X1 -?- X2.

% проверяет существует ли путь от вершины V1 в вершину V2
% синтаксис:
% <Граф с вершинами V и ребрами E> : <Первая вершина> -?- <вторая вершина>
(V,E) : V1 -?- V2 -> Way :- 
    (V,E): V1 -- V2, Way ~ [V1,V2];
    (V,E): V1 -- X1,
    (V,E): V2 -- X2, 

    (V,E): X1 -?- X2 -> NextWay,
    pushBack([V1|NextWay],V2, Way).

% явзяется ли граф связанным
is_constrain((V,E)) :-
    V ~ [H|T],
    allList(
        [Vertex]>>(
            (V,E): H -?- Vertex
        ),
        V 
    ),!.

% явзяется ли граф деревом
is_tree((V,E)) :-
    allList(
        [Vertex]>>(
            (V,E): Vertex--V1,
            (V,E): Vertex--V2,
            (V,E): V1-?-V2,
            not(V1 is V2)
        ),
        V 
    ),!.

unique(X) :-
    generateUniqueList(X,UX),
    length(X,L),
    length(UX,L).