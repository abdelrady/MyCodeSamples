female(hoda).
female(soha).
female(arwa).
female(hind).
male(ali).
male(hosam).
male(amr).
male(saber).
male(ahmed).
male(sayed).
male(hasan).
parent(ali,hosam).
parent(ali,amer).
parent(ali,soha).
parent(hoda,hosam).
parent(hoda,amer).
parent(hoda,soha).
parent(hosam,ahmed).
parent(hosam,sayed).
parent(amera,ahmed).
parent(amera,sayed).
parent(amr,arwa).
parent(hind,arwa).
parent(soha,hasan).
parent(saber,hasan).
husband(ali,hoda).
husband(hosam,amera).
husband(amer,hind).
husband(saber,soha).
wife(X,Y):-
	husband(Y,X).
father(X,Y):-
	parent(X,Y),
	male(X).
mother(X,Y):-
	parent(X,Y),
	female(X).
brother(X,Y):-
	parent(Z,X),
	parent(Z,Y),
	male(X).		
sister(X,Y):-
	parent(Z,X),
	parent(Z,Y),
	female(X).
sibling(X,Y):-
	parent(Z,X),
	parent(Z,Y).
cousin(X,Y):-
	parent(Z,X),
	parent(W,Y),
	parent(T,Z),
	parent(T,W).			
grandparent(X,Y):-
	parent(Z,Y),
	parent(X,Z).
grandfather(X,Y):-
	parent(Z,Y),
	parent(X,Z),
	male(X).
grandmother(X,Y):-
	parent(Z,Y),
	parent(X,Z),
	female(X).		
uncle(X,Y):-
	parent(Z,X),
	grandparent(Z,Y),
	male(X).
aunt(X,Y):-
	parent(Z,X),
	grandparent(Z,Y),
	female(X).
decendant(X,Y):-
	grandparent(Y,X).
	