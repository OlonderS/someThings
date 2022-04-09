#include <stdio.h>
#include <stdlib.h>

struct StructWezel
{
	int wartosc;
	struct StructWezel* lewy;
	struct StructWezel* prawy;
	struct StructWezel* rodzic;
}StructWezel;

void dodaj_wezel(struct StructWezel* korzen, int wartosc)
{
	struct StructWezel* nowy = malloc(sizeof(struct StructWezel));
	nowy->wartosc = wartosc;
	nowy->prawy = NULL;
	nowy->lewy = NULL;
	nowy->rodzic = NULL;
	if (korzen == NULL)
	{
		korzen = nowy;
		return;
	}
	while (1)
	{
		if (korzen->wartosc <= wartosc)
		{
			if (korzen->prawy != NULL)
			{
				korzen = korzen->prawy;
			}
			else
			{
				korzen->prawy = nowy;
				nowy->rodzic = korzen;
				break;
			}
		}
		else
		{
			if (korzen->lewy != NULL)
			{
				korzen = korzen->lewy;
			}
			else
			{
				korzen->lewy = nowy;
				nowy->rodzic = korzen;
				break;
			}
		}
	}
}

void usun_wezel(struct StructWezel* korzen, int wartosc) 
{
	if (korzen == NULL)
	{
		return;
	}
	if (wartosc > korzen->wartosc)
	{
		usun_wezel(korzen->prawy, wartosc);
	}
	else if (wartosc < korzen->wartosc)
	{
		usun_wezel(korzen->lewy, wartosc);
	}
	else 
	{
		if (korzen->lewy == NULL) 
		{
			struct StructWezel* tmp = korzen->prawy;
			tmp->rodzic = korzen->rodzic;
			if (korzen->rodzic!=NULL) 
			{
				if (korzen->rodzic->lewy == korzen)
				{
					korzen->rodzic->lewy = tmp;
				}
				else
				{
					korzen->rodzic->prawy = tmp;
				}
			}
			free(korzen);
			return;
		}
		else if (korzen->prawy == NULL) 
		{
			struct StructWezel* tmp = korzen->lewy;
			tmp->rodzic = korzen->rodzic;
			if (korzen->rodzic) 
			{
				if (korzen->rodzic->lewy == korzen)
				{
					korzen->rodzic->lewy = tmp;
				}
				else
				{
					korzen->rodzic->prawy = tmp;
				}
			}
			free(korzen);
			return;
		}
		struct StructWezel* tmp = korzen->prawy;
		while (tmp->lewy != NULL)
		{
			tmp = tmp->lewy;
		}
		korzen->wartosc = tmp->wartosc;
		usun_wezel(korzen->prawy, tmp->wartosc);
	}
}

struct StructWezel* znajdz_min(struct StructWezel* korzen) 
{
	while (korzen->lewy!=NULL)
	{
		korzen = korzen->lewy;
	}
	return korzen;
}

struct StructWezel* znajdz_max(struct StructWezel* korzen) 
{
	while (korzen->prawy!=NULL)
	{
		korzen = korzen->prawy;
	}
	return korzen;
}