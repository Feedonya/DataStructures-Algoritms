import math
from heapq import heappush, heappop
from collections import defaultdict

# Координаты вершин
coords = {
    0: (0, 0),         # Саратов
    1: (25, -20),      # Энгельс
    2: (100, 50),      # Маркс
    3: (250, 125),     # Балаково
    4: (-75, -100),    # Березовка
    5: (100, -50),     # Степное
    6: (200, -75),     # Мокроус
    7: (300, -65),     # Ершов
    8: (20, 200),      # Яковлевка
    9: (-50, 100)      # Озерки
}

# Имена вершин
names = ["А", "Б", "В", "Г", "Д",
         "Е", "Ж", "З", "И", "К"]

# Матрица смежности
adj_matrix = [
    [0,1,0,0,0,0,0,0,1,1],
    [1,0,1,0,1,1,0,0,0,0],
    [0,1,0,1,0,1,1,1,0,0],
    [0,0,1,0,0,1,1,1,0,0],
    [0,1,0,0,0,0,0,0,0,0],
    [0,1,1,1,0,0,1,0,0,0],
    [0,0,1,1,0,1,0,1,0,0],
    [0,0,1,1,0,0,1,0,0,0],
    [1,0,0,0,0,0,0,0,0,1],
    [1,0,0,0,0,0,0,0,1,0]
]

# Функция для вычисления веса ребра (евклидово расстояние)
def edge_weight(u, v):
    x1, y1 = coords[u]
    x2, y2 = coords[v]
    return math.hypot(x1 - x2, y1 - y2)

# Построение списка смежности
graph = defaultdict(list)
for i in range(10):
    for j in range(10):
        if adj_matrix[i][j]:
            graph[i].append((j, edge_weight(i, j)))

# Алгоритм Дейкстры для одной вершины
def dijkstra(start, n):
    dist = [float('inf')] * n
    dist[start] = 0
    heap = [(0, start)]

    while heap:
        current_dist, u = heappop(heap)
        if current_dist > dist[u]:
            continue
        for v, w in graph[u]:
            if dist[v] > dist[u] + w:
                dist[v] = dist[u] + w
                heappush(heap, (dist[v], v))
    return dist

# Вычисление всех пар кратчайших расстояний
n = 10
shortest_paths = []
for i in range(n):
    shortest_paths.append(dijkstra(i, n))

# Вывод таблицы кратчайших расстояний
print("Кратчайшие расстояния между всеми парами городов:")
header = "\t".join([""] + names)
print(header)
for i in range(n):
    row = [names[i]] + [f"{shortest_paths[i][j]:.2f}" if shortest_paths[i][j] != float('inf') else "∞" for j in range(n)]
    print("\t".join(row))