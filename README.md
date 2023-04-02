# iot_visualization_distributionTask

Пересобрать образ:
docker build --force-rm -t robinsonbastard/distribution_task .

Создать контейнер из образа:
docker run -it -p 3001:8001 --name homework_iot robinsonbastard/distribution_task

Запусить уже готовый контейнер:
docker start homework_iot -i