#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char* zad11_1(char* tab, int n)
{
	char* result = malloc(sizeof(char) * n * 8 + 1);
	result[8 * n] = '\0';
	int c = 0;
	for (int i = 0; i < n; ++i)
	{
		int x = (int)tab[i];
		for (int j = 7; j >= 0; j--)
		{
			int tmp = x >> j;
			if (tmp & 1)
			{
				result[c] = '1';
			}
			else
			{
				result[c] = '0';
			}
			++c;
		}
	}
	return result;
}

void zad11_2(char* tab, int n)
{
	if (n % 8)
	{
		printf("Bledne dane ");
		return;
	}
	int x = 0;
	char* result = (char*)malloc(sizeof(char) * n / 8 + 1);
	result[n / 8] = '\0';
	for (int i = 0; i < n / 8; i++)
	{
		int l = 0;
		for (int j = 0; j < 8; j++)
			l += (tab[i * 8 + j] - '0') << (7 - j);
		printf("%c", l + '0');
	}
}

void zad11_3()
{
	int x;
	char tmp[1];
	FILE* Fin;
	FILE* Fout;
	fopen_s(&Fin, "in.txt", "r");
	fopen_s(&Fout, "out.txt", "w");
	if (Fin && Fout)
	{
		while ((x = getc(Fin)) != EOF)
		{
			tmp[0] = (char)x;
			fprintf(Fout, "%s", zad11_1(tmp, 1));
		}
	}
	else if (!Fin)
	{
		perror("in.txt");
	}
	else if (!Fout)
	{
		perror("out.txt");
	}
	if (Fin)
	{
		fclose(Fin);
	}
	if (Fout)
	{
		fclose(Fout);
	}
}


struct AdjListNode
{
	int dest;
	struct AdjListNode* next;
};

struct AdjList
{
	struct AdjListNode* head;
};

struct Graph
{
	int V;
	struct AdjList* array;
};

struct AdjListNode* newAdjListNode(int dest)
{
	struct AdjListNode* newNode = (struct AdjListNode*) malloc(sizeof(struct AdjListNode));
	newNode->dest = dest;
	newNode->next = NULL;
	return newNode;
}
/*
struct Graph* createGraph(int V)
{
	struct Graph* graph = (struct Graph*) malloc(sizeof(struct Graph));
	graph->V = V;
	graph->array = (struct AdjList*) malloc(V * sizeof(struct AdjList));
	for (int i = 0; i < V; ++i)
	{
		graph->array[i].head = NULL;
	}
	return graph;
}

void addEdge(struct Graph* graph, int src, int dest)
{
	struct AdjListNode* newNode = newAdjListNode(dest);
	newNode->next = graph->array[src].head;
	graph->array[src].head = newNode;
	*/