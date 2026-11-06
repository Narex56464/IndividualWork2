mysql> SHOW INDEX FROM booking.appointments WHERE Key_name = 'uniq_specialist_slot';
+--------------+------------+----------------------+--------------+---------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+------------+
| Table        | Non_unique | Key_name             | Seq_in_index | Column_name   | Collation | Cardinality | Sub_part | Packed | Null | Index_type | Comment | Index_comment | Visible | Expression |
+--------------+------------+----------------------+--------------+---------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+------------+
| appointments |          0 | uniq_specialist_slot |            1 | specialist_id | A         |           1 |     NULL |   NULL |      | BTREE      |         |               | YES     | NULL       |
| appointments |          0 | uniq_specialist_slot |            2 | appt_date     | A         |           1 |     NULL |   NULL |      | BTREE      |         |               | YES     | NULL       |
| appointments |          0 | uniq_specialist_slot |            3 | appt_time     | A         |           2 |     NULL |   NULL |      | BTREE      |         |               | YES     | NULL       |
+--------------+------------+----------------------+--------------+---------------+-----------+-------------+----------+--------+------+------------+---------+---------------+---------+------------+
3 rows in set (1.13 sec)
